using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] protected GameObject explosionFX;

    [SerializeField] protected int pointsByEnemy;

    [Header("Status Variables")]
    [SerializeField] protected float speed;
    [SerializeField] protected int enemyHP;

    [Header("Shot Variables")]
    [SerializeField] protected GameObject enemyShot;
    [SerializeField] protected float shotSpeed;
    [SerializeField] protected float maxShotTime;
    protected float currentShotTime;

    public void EnemyHit(int damage)
    {
        enemyHP -= damage;
        Debug.Log(enemyHP);

        if (enemyHP <= 0f)
        {
            Instantiate(explosionFX, transform.position, Quaternion.identity);
            Destroy(gameObject);

            FindObjectOfType<SpawEnemies>().PointsToGive(pointsByEnemy);
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
