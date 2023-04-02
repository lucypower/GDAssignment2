using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int m_playerHealth;
    [HideInInspector] public string m_playerHealthEnd = "PlayerHealth";
    [HideInInspector] public string m_playerWalkSpeed = "WalkSpeed";
    [HideInInspector] public string m_playerRange = "Range";
    [HideInInspector] public string m_playerDamage = "Damage";
    [HideInInspector] public string m_playerBPS = "BulletPerSecond";
    GameManager m_gameManager;

    private void Start()
    {
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        int currentFloor = PlayerPrefs.GetInt(m_gameManager.m_floorNumber);

        if (currentFloor == 1)
        {
            m_playerHealth = 100;
            PlayerPrefs.SetInt(m_playerHealthEnd, 100);
            PlayerPrefs.SetInt(m_playerWalkSpeed, 10);
            PlayerPrefs.SetInt(m_playerRange, 7);
            PlayerPrefs.SetInt(m_playerDamage, 2);
            PlayerPrefs.SetInt(m_playerBPS, 2);

            PlayerPrefs.Save();
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
