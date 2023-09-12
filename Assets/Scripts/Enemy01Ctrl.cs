using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01Ctrl : Enemies
{
    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(0f, -speed);
        shotTimerCurrent = shotTimer;
    }

    // Update is called once per frame
    void Update()
    {
        Shot();
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
        var shotInst = Instantiate(enemyShot, firePoint.transform.position, Quaternion.identity);
        shotTimerCurrent = shotTimer;
    }
}
