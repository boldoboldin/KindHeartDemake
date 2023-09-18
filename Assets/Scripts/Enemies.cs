using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [Header("Status Variables")]
    [SerializeField] protected float speed;
    [SerializeField] protected int enemyHP;

    [SerializeField] protected GameObject explosionFX;

    [Header("Shot Variables")]
    [SerializeField] protected GameObject enemyShot;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float shotSpeed;
    [SerializeField] protected float maxShotTime;
    protected float currentShotTime;

    public void EnemyHit(int damage)
    {
        enemyHP =- damage;

        if (enemyHP <= 0f)
        {
            Instantiate(explosionFX, firePoint.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
