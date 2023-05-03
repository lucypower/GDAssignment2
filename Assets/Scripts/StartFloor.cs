using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartFloor : MonoBehaviour
{
    GameManager m_gameManager;

    [SerializeField] private TMP_Text m_text;
    private int m_floorNumber;

    private void Start()
    {
        m_gameManager = GetComponent<GameManager>();
        m_floorNumber = PlayerPrefs.GetInt(m_gameManager.m_floorNumber);

        Invoke(nameof(ShowText), 0.5f);
    }

    private void ShowText()
    {
        m_text.text = "Floor : " + m_floorNumber;
        Invoke(nameof(HideText), 3f);
    }

    private void HideText()
    {
        m_text.text = "";
    }
}
