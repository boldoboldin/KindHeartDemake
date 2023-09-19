
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField] private float speed;

    [SerializeField] private float playerHP;

    [SerializeField] private GameObject explosionFX;

    [Header("Shot Variables")]
    [SerializeField] private GameObject playerShot;
    [SerializeField] private Transform firePointM;
    [SerializeField] private Transform firePointL;
    [SerializeField] private Transform firePointR;
    [SerializeField] private float shotSpeed;
    [SerializeField] private float maxShotTime;
    private float currentShotTime;
    public int shotMode;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentShotTime = maxShotTime;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shot();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 playerVel = new Vector2(horizontal, vertical);

        //playerVel.Normalize();

        rb2D.velocity = playerVel * speed;
    }

    private void Shot()
    {
        currentShotTime -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && currentShotTime <= 0)
        {
            Fire();
        }
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

        currentShotTime = maxShotTime;
    }

    public void PlayerHit(int damage)
    {
        playerHP = playerHP - damage;

        if (playerHP <= 0)
        {
            Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
