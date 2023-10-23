using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy02Ctrl : Enemies
{
    private Rigidbody2D rb2D;

    [SerializeField] protected Transform firePoint;

    [SerializeField] private float yMax = 2.5f;
    [SerializeField] private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(0f, -speed);
        currentShotTime = maxShotTime;
    }

    // Update is called once per frame
    void Update()
    {
        Shot();

        if (transform.position.y < yMax && canMove)
        {
            if (transform.position.x < 0)
            {
                rb2D.velocity = new Vector2(speed, -speed);
                canMove = false;
            }
            else
            {
                rb2D.velocity = new Vector2(-speed, -speed);
                canMove = false;
            }

        }
    }

    private void Shot()
    {
        bool visible = GetComponentInChildren<SpriteRenderer>().isVisible;

        if (visible)
        {
            var player = FindObjectOfType<PlayerCtrl>();

            if (player != null)
            {
                currentShotTime -= Time.deltaTime;

                if (currentShotTime <= 0)
                {
                    Fire();
                }
            }
        }
    }

    void Fire()
    {
        var shotInst =  Instantiate(enemyShot, firePoint.transform.position, Quaternion.identity);

        Vector2 direction = (enemyShot.transform.position - shotInst.transform.position).normalized;

        shotInst.GetComponent<Rigidbody2D>().velocity = direction * shotSpeed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        shotInst.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        currentShotTime = maxShotTime;
    }
}
