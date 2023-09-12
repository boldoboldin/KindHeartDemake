using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy02Ctrl : Enemies
{
    private Rigidbody2D rb2D;
    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Shot();

        if(transform.position.y < yMax && canMove)
        {
            if(transform.position.y < 0)
            {
                rb2D.velocity = new Vector2(speed, - speed);
            }
            
        }
    }

    private void Shot()
    {
        bool visible = GetComponentInChildren<SpriteRenderer>().isVisible;

        if (visible)
        {
            shotTimerCurrent -= Time.deltaTime;

            if (shotTimerCurrent <= 0)
            {
                Fire();
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

        shotTimerCurrent = shotTimer;
    }
}
