using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnScreenStats : MonoBehaviour
{
    PlayerStats m_playerStats;

    [SerializeField] private TMP_Text m_damageText;
    [SerializeField] private TMP_Text m_rangeText;
    [SerializeField] private TMP_Text m_fireRateText;
    [SerializeField] private Image m_healthBar;

    private int m_health;

    private void Start()
    {
        m_playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();

        UpdateStats();
        Invoke(nameof(UpdateHealthBar), 0.1f);
    }

    public void UpdateStats()
    {
        int damage = PlayerPrefs.GetInt(m_playerStats.m_playerDamage);
        int range = PlayerPrefs.GetInt(m_playerStats.m_playerRange);
        float fireRate = PlayerPrefs.GetFloat(m_playerStats.m_playerBPS);

        m_damageText.text = "DMG : " + damage;
        m_rangeText.text = "RNG : " + range;
        m_fireRateText.text = "FR : " + fireRate;
    }

    public void UpdateHealthBar()
    {
        m_healthBar.fillAmount = Mathf.Clamp(m_playerStats.m_playerHealth / 100, 0, 1);
    }
}
