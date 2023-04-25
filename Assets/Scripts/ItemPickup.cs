using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    PlayerStats m_playerStats;
    OnScreenStats m_onScreenStats;

    [SerializeField] private string m_itemStat;
    [SerializeField] private int m_statNumber;
    [SerializeField] private TMP_Text m_text;

    private void Awake()
    {
        m_playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        m_onScreenStats = GameObject.Find("Stats").GetComponent<OnScreenStats>();
        m_text = GameObject.Find("ItemStats").GetComponent<TMP_Text>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CheckItemStats();
            gameObject.SetActive(false);
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

                break;

            case "Range":

                int range = PlayerPrefs.GetInt(m_playerStats.m_playerRange);
                range += m_statNumber;

                PlayerPrefs.SetInt(m_playerStats.m_playerRange, range);

                break;

            case "Damage":

                int damage = PlayerPrefs.GetInt(m_playerStats.m_playerDamage);
                damage += m_statNumber;

                PlayerPrefs.SetInt(m_playerStats.m_playerDamage, damage);

                break;

            default:
                break;
        }

        PlayerPrefs.Save();
        m_onScreenStats.UpdateStats();

        m_text.text = m_itemStat + " : " + m_statNumber;
        Invoke(nameof(TextDisappear), 3.0f);
    }

    private void TextDisappear()
    {
        m_text.text = " ";
        Destroy(gameObject);
    }    
}
