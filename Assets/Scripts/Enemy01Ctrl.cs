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
        currentShotTime = maxShotTime;
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
            currentShotTime -= Time.deltaTime;

            if (currentShotTime <= 0)
            {
                Fire();
            }
        }
    }

    void Fire()
    {
        var shotInst = Instantiate(enemyShot, firePoint.position, firePoint.rotation);
        shotInst.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -shotSpeed);
        currentShotTime = maxShotTime;
    }
}
