using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int m_damage;

    PlayerStats m_playerStats;

    private void Awake()
    {
        m_playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    public void DoDamage(int damage)
    {
        int health = PlayerPrefs.GetInt(m_playerStats.m_playerHealth);
        health -= damage;

        PlayerPrefs.SetInt(m_playerStats.m_playerHealth, health);
        PlayerPrefs.Save();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DoDamage(m_damage);
        }
    }
}
