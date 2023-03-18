using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    EnemyManager m_enemyManager;

    private void Awake()
    {
        m_enemyManager = GetComponentInParent<EnemyManager>();
    }

    public void Death()
    {
        m_enemyManager.m_enemies.Remove(gameObject);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Death();
            Destroy(collision.gameObject);
        }
    }
}
