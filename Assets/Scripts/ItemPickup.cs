using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickup : MonoBehaviour
{
    PlayerStats m_playerStats;

    [SerializeField] private string m_itemStat;
    [SerializeField] private int m_statNumber;
    [SerializeField] private TMP_Text m_text;


    private void Awake()
    {
        m_playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
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

        m_text.text = m_itemStat + " : " + m_statNumber;
        Debug.Log("Calling");
        Invoke("disappearing", 3.0f);
        //
        //StartCoroutine(ShowText(3));
    }

    private void disappearing()
    {
        m_text.text = " ";
        Destroy(gameObject);
    }

    IEnumerator ShowText(int waitTime)
    {
        m_text.text = m_itemStat + " : " + m_statNumber;

        yield return new WaitForSeconds(waitTime);

        //for (int i = 0; i < m_text.text.Length; i++)
        //{
        //    m_text.text = m_text.text.Remove(i);
        //}

        //m_text.text = " ";
        //Destroy(gameObject);

        //StopCoroutine(ShowText(3));
    }

    
}
