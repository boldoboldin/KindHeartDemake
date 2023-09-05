using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01Ctr : Enemies
{
    private Rigidbody2D rb2D;

    private GameObject player;

    [SerializeField] private float distY;
    [SerializeField] private float distMin;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        shotTimer = 0.5f; 
        player = GameObject.FindGameObjectWithTag("Player");

        rb2D.velocity = new Vector2(0f, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        Shot();
    }

    private void Shot()
    {
        distY = transform.position.y - player.transform.position.y;

        shotCount -= Time.deltaTime;

        if (distY <= distMin && shotCount <= 0)
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(playerShot, firePoint.transform.position, Quaternion.identity);
        shotCount = shotTimer;
        shotTimer = Random.Range(0.1f, 3f);
    }

}
