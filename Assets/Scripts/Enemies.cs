using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [Header("Status Variables")]
    [SerializeField] protected float speed;
    [SerializeField] protected int hp;

    [SerializeField] protected GameObject explosionFX;

    [Header("Shot Variables")]
    [SerializeField] protected GameObject enemyShot;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float shotSpeed;
    [SerializeField] protected float shotTimer;
    protected float shotTimerCurrent;

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
