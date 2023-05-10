using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    PlayerStats m_playerStats;
    OnScreenStats m_onScreenStats;

    [SerializeField] private string m_itemStat;
    [SerializeField] private float m_statNumber;
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

                float speed = PlayerPrefs.GetFloat(m_playerStats.m_playerWalkSpeed);
                speed += (int)m_statNumber;

                PlayerPrefs.SetFloat(m_playerStats.m_playerWalkSpeed, speed);

                break;

            case "Range":

                float range = PlayerPrefs.GetFloat(m_playerStats.m_playerRange);
                range += (int)m_statNumber;

                PlayerPrefs.SetFloat(m_playerStats.m_playerRange, range);

                break;

            case "Damage":

                float damage = PlayerPrefs.GetFloat(m_playerStats.m_playerDamage);

                damage += m_statNumber;

                PlayerPrefs.SetFloat(m_playerStats.m_playerDamage, damage);

                break;

            case "BPS":

                float bps = PlayerPrefs.GetFloat(m_playerStats.m_playerBPS);

                if ((bps - m_statNumber) <= 0)
                {
                    bps = 0.1f;
                }

                bps += m_statNumber;

                PlayerPrefs.SetFloat(m_playerStats.m_playerBPS, bps);

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
