using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextFloor : MonoBehaviour
{
    GameManager m_gameManager;
    public int currentFloor;

    private void Awake()
    {
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentFloor = PlayerPrefs.GetInt(m_gameManager.m_floorNumber);
    }

    public void LoadNextFloor()
    {
        SetFloor();
        Invoke(nameof(Reload), 0.5f);
    }

    private void SetFloor()
    {
        currentFloor++;
        PlayerPrefs.SetInt(m_gameManager.m_floorNumber, currentFloor);
        PlayerPrefs.Save();
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
