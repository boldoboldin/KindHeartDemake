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
        enemyHP -= damage;
        Debug.Log(enemyHP);

        if (enemyHP <= 0f)
        {
            Instantiate(explosionFX, firePoint.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerCtrl>().PlayerHit(1);
            Instantiate(explosionFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
