using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected int hp;

    [SerializeField] protected GameObject explosionFX;

    [Header("Shot Variables")]
    [SerializeField] protected GameObject playerShot;
    [SerializeField] protected Transform firePoint;
    protected float shotTimer;
    protected float shotCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void fire()
    {
        Instantiate(playerShot, firePoint.transform.position, Quaternion.identity);
        shotCount = shotTimer;
        shotTimer = Random.Range(0.1f, 3f);
    }

    public void EnemyHit(int damage)
    {
        hp =- damage;

        if (hp < 0f)
        {
            Instantiate(explosionFX, firePoint.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}
