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
    [SerializeField] private TMP_Text m_walkSpeedText;
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
        float damage = PlayerPrefs.GetFloat(m_playerStats.m_playerDamage);
        float range = PlayerPrefs.GetFloat(m_playerStats.m_playerRange);
        float fireRate = PlayerPrefs.GetFloat(m_playerStats.m_playerBPS);
        float walkSpeed = PlayerPrefs.GetFloat(m_playerStats.m_playerWalkSpeed);

        m_damageText.text = "DMG : " + damage;
        m_rangeText.text = "RNG : " + range;
        m_fireRateText.text = "FR : " + fireRate;
        m_walkSpeedText.text = "WLK : " + walkSpeed;
    }

    public void UpdateHealthBar()
    {
        m_healthBar.fillAmount = Mathf.Clamp(m_playerStats.m_playerHealth / 100, 0, 1);
    }
}
