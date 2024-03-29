using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    EnemyManager m_enemyManager;
    EnemyStats m_enemyStats;
    PlayerStats m_playerStats;

    float m_playerDamage;

    private void Awake()
    {
        m_enemyManager = GetComponentInParent<EnemyManager>();
        m_enemyStats = GetComponent<EnemyStats>();
        m_playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();

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
            m_playerDamage = PlayerPrefs.GetFloat(m_playerStats.m_playerDamage);
            m_enemyStats.m_health -= (int)m_playerDamage;
            Destroy(collision.gameObject);

            if (m_enemyStats.m_health <= 0)
            {
                Death();
            }
        }
    }
}
