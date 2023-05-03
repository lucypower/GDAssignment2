using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextFloor : MonoBehaviour
{
    GameManager m_gameManager;
    PlayerStats m_playerStats;
    [HideInInspector] public int m_currentFloor;

    private void Awake()
    {
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        m_playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        m_currentFloor = PlayerPrefs.GetInt(m_gameManager.m_floorNumber);
    }

    public void LoadNextFloor()
    {
        SetFloor();
        SaveHealth();
        Invoke(nameof(Reload), 0.5f);
    }

    private void SetFloor()
    {
        m_currentFloor++;
        PlayerPrefs.SetInt(m_gameManager.m_floorNumber, m_currentFloor);
        PlayerPrefs.Save();
    }

    private void SaveHealth()
    {
        PlayerPrefs.SetInt(m_playerStats.m_playerHealthEnd, (int)m_playerStats.m_playerHealth);
    }

    private void Reload()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision");
            LoadNextFloor();
        }
    }
}
