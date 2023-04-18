using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    PlayerStats m_playerStats;

    [SerializeField] private string m_itemStat;
    [SerializeField] private int m_statNumber;


    private void Awake()
    {
        m_playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CheckItemStats();
            Destroy(gameObject);
        }
    }

    private void CheckItemStats()
    {
        switch (m_itemStat)
        {
            case "WalkSpeed":

                int speed = PlayerPrefs.GetInt(m_playerStats.m_playerWalkSpeed);
                speed += m_statNumber;

                PlayerPrefs.SetInt(m_playerStats.m_playerWalkSpeed, speed);
                PlayerPrefs.Save();

                break;

            case "Range":

                int range = PlayerPrefs.GetInt(m_playerStats.m_playerRange);
                range += m_statNumber;

                PlayerPrefs.SetInt(m_playerStats.m_playerRange, range);
                PlayerPrefs.Save();

                break;

            case "Damage":

                int damage = PlayerPrefs.GetInt(m_playerStats.m_playerDamage);
                damage += m_statNumber;

                PlayerPrefs.SetInt(m_playerStats.m_playerDamage, damage);
                PlayerPrefs.Save();

                break;

            default:
                break;
        }
    }
}
