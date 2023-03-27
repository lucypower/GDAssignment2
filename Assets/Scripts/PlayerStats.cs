using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [HideInInspector] public string m_playerHealth = "PlayerHealth";
    [HideInInspector] public string m_playerWalkSpeed = "WalkSpeed";
    [HideInInspector] public string m_playerRange = "Range";
    [HideInInspector] public string m_playerDamage = "Damage";
    GameManager m_gameManager;

    private void Start()
    {
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (!PlayerPrefs.HasKey(m_playerHealth))
        {
            PlayerPrefs.SetInt(m_playerHealth, 100);
        } // TODO: Delete this pref on exit of game and new game loaded

        if (!PlayerPrefs.HasKey(m_playerWalkSpeed))
        {
            PlayerPrefs.SetInt(m_playerWalkSpeed, 1);
        }

        if (!PlayerPrefs.HasKey(m_playerRange))
        {
            PlayerPrefs.SetInt(m_playerRange, 2);
        }

        if (!PlayerPrefs.HasKey(m_playerDamage))
        {
            PlayerPrefs.SetInt(m_playerDamage, 2);
        }
    }

    private void Update()
    {
        //if (m_health <= 0)
        //{
        //    // TODO: Rest of player death
        //    //PlayerPrefs.SetInt(m_gameManager.m_floorNumber, 1);
        //}
    }
}
