using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private List<int> m_itemStats; // TODO: Look into using a dictionary instead
    PlayerStats m_playerStats;

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
        for (int i = 0; i < m_itemStats.Count; i++)
        {
            if (m_itemStats[i] != 0) // is currently adding list index not contents, also going into the wrong case
            {
                switch (m_itemStats[i])
                {
                    case 0: // walk speed

                        int speed = PlayerPrefs.GetInt(m_playerStats.m_playerWalkSpeed);
                        speed += m_itemStats[i];
                        PlayerPrefs.SetInt(m_playerStats.m_playerWalkSpeed, speed);
                        PlayerPrefs.Save();

                        break;

                    case 1: // range

                        int range = PlayerPrefs.GetInt(m_playerStats.m_playerRange);
                        range += m_itemStats[i];
                        PlayerPrefs.SetInt(m_playerStats.m_playerRange, range);
                        PlayerPrefs.Save();

                        break;

                    case 2: // damage

                        int damage = PlayerPrefs.GetInt(m_playerStats.m_playerDamage);
                        damage += m_itemStats[i];
                        PlayerPrefs.SetInt(m_playerStats.m_playerDamage, damage);
                        PlayerPrefs.Save();

                        break;

                    default:
                        break;
                }
            }
        }
    }
}
