using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class BossController : Enemies
{
    [SerializeField] private string state = "state01";
    //[SerializeField] private float bossSpeed = 2f;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private bool toTheRight;
    [SerializeField] private float xOffset;

    [Header("Shots and Points")]
    [SerializeField] private GameObject shotOnePrefab;
    [SerializeField] private GameObject shotTwoPrefab;
    [SerializeField] private Transform shotPointLeft;
    [SerializeField] private Transform shotPointRight;
    [SerializeField] private Transform shotPointMiddle;
    [SerializeField] private float waitToShot = 2f;
    [SerializeField] private float waitToShotTwo = 1.5f;
    [SerializeField] private float chargeTime = 2f;

    [Header("Possibles IAs States")]
    [SerializeField] private string[] possiblesStates;
    [SerializeField] private float waitToChangeState = 10f;

    [Header("HP")]
    [SerializeField] private Image lifeBar;
    [SerializeField] private int maxHP;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case "state01":
                State01();
                break;

            case "state02":
                State02();
                break;

            case "state03":
                State03();
                break;
        }

        ChangeState();
        MoveOnScreen();

        lifeBar.fillAmount = (float) enemyHP / (float) maxHP;
    }


    private void State03()
    {
        if (waitToShot <= 0f)
        {
            ShotOne();
            waitToShot = chargeTime;
        }

        if (waitToShotTwo <= 0f)
        {
            ShotTwo();
            waitToShotTwo = chargeTime / 2;
        }
        else
        {
            waitToShot -= Time.deltaTime;
            waitToShotTwo -= Time.deltaTime;
        }
    }

    private void State02()
    {
        if (waitToShot <= 0)
        {
            ShotTwo();
            waitToShot = chargeTime / 2f;
        }
        else
        {
            waitToShot -= Time.deltaTime;
        }
    }

    private void State01()
    {
        if (waitToShot <= 0)
        {
            ShotOne();
            waitToShot = chargeTime;
        }
        else
        {
            waitToShot -= Time.deltaTime;
        }

    }

    private void ShotOne()
    {
        GameObject shot = Instantiate(shotOnePrefab, shotPointLeft.position, shotPointLeft.rotation);
        shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -shotSpeed);

        shot = Instantiate(shotOnePrefab, shotPointRight.position, shotPointRight.rotation);
        shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -shotSpeed);
    }

    private void ShotTwo()
    {
        var player = FindObjectOfType<PlayerCtrl>();

        if (player != null)
        {
            var shotInst = Instantiate(shotTwoPrefab, shotPointMiddle.position, shotPointMiddle.rotation);

            Vector2 direction = (player.transform.position - shotInst.transform.position).normalized;

            shotInst.GetComponent<Rigidbody2D>().velocity = direction * shotSpeed;
        }

    }

    private void ChangeState()
    {
        if (waitToChangeState <= 0)
        {
            int stateIndex = Random.Range(0, possiblesStates.Length);
            state = possiblesStates[stateIndex];
            waitToChangeState = chargeTime;
        }
        else
        {
            waitToChangeState -= Time.deltaTime;
        }

    }

    private void MoveOnScreen()
    {

        if (toTheRight)
        {
            rb2d.velocity = new Vector2(speed, 0f);
        }
        else
        {
            rb2d.velocity = new Vector2(-speed, 0f);
        }

        if (transform.position.x >= xOffset)
        {
            toTheRight = false;
        }
        else if (transform.position.x <= -xOffset)
        {
            toTheRight = true;
        }
    }
}