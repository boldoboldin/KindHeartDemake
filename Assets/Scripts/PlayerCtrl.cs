
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField] private float speed;

    [SerializeField] private float hp;

    [Header("Shot Variables")]
    [SerializeField] private GameObject playerShot;
    [SerializeField] private Transform firePointM;
    [SerializeField] private Transform firePointL;
    [SerializeField] private Transform firePointR;
    [SerializeField] private float shotSpeed;
    [SerializeField] private float shotTimer;
    private float shotTimerCurrent;
    public int shotMode;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        shotTimerCurrent = shotTimer;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        shotTimerCurrent -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && shotTimerCurrent <= 0)
        {
            Fire();
        }
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 playerVel = new Vector2(horizontal, vertical);

        //playerVel.Normalize();

        rb2D.velocity = playerVel * speed;
    }

    void Fire()
    {        
        if (shotMode == 0)
        {
            Instantiate(playerShot, firePointM.transform.position, Quaternion.identity);
        }

        if (shotMode == 1)
        {
            Instantiate(playerShot, firePointL.transform.position, Quaternion.identity);
            Instantiate(playerShot, firePointR.transform.position, Quaternion.identity);
        }

        if (shotMode == 2)
        {
            Instantiate(playerShot, firePointM.transform.position, Quaternion.identity);
            Instantiate(playerShot, firePointL.transform.position, Quaternion.identity);
            Instantiate(playerShot, firePointR.transform.position, Quaternion.identity);
        }

        shotTimerCurrent = shotTimer;
    }

    public void PlayerHit(int damage)
    {
        hp = hp - damage;
    }
}
