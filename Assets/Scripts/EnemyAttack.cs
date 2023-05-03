using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int m_damage;

    PlayerStats m_playerStats;
    OnScreenStats m_onScreenStats;

    private void Awake()
    {
        m_playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        m_onScreenStats = GameObject.Find("Stats").GetComponent<OnScreenStats>();
    }

    public void DoDamage(int damage)
    {
        m_playerStats.m_playerHealth -= damage;
        m_onScreenStats.UpdateHealthBar();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DoDamage(m_damage);
        }
    }
}
