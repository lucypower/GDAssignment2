using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float m_damage;

    PlayerStats m_playerStats;

    private void Awake()
    {
        m_playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    public void DoDamage(float damage)
    {
        m_playerStats.m_health -= damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DoDamage(m_damage);
        }
    }
}
