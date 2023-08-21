
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField] private float speed;

    [Header("Shot Variables")]
    [SerializeField] private GameObject playerShot;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float shotTimer;
    public float shotCount;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        // Pegando os inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 playerVel = new Vector2(horizontal, vertical);

        //playerVel.Normalize();

        rb2D.velocity = playerVel * speed;

        shotCount -= Time.deltaTime;

        if (Input.GetButton("Fire1") && shotCount <= 0)
        {
            fire();
        }
    }

    void fire()
    {        
        Instantiate(playerShot, firePoint.transform.position, Quaternion.identity);
        shotCount = shotTimer;
    }
}
