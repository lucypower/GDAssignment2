using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool m_isPaused;

    private void Awake()
    {
        m_isPaused = false;
    }

    public void UnPause()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Debug.Log("PauseMenu");
        if (!m_isPaused)
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
            m_isPaused = true;
        }
        else if (m_isPaused)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
            m_isPaused = false;
        }
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        m_isPaused = false;
    }
}
