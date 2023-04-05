using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    [SerializeField] private Transform m_mainMenu;
    [SerializeField] private Transform m_settingsMenu;
    [SerializeField] private Transform m_tutorialMenu;
    [SerializeField] private Transform m_quitMenu;

    [SerializeField] private Transform m_targetLocation;

    public int m_moveSpeed;

    private void Awake()
    {
        m_targetLocation = m_mainMenu;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, m_targetLocation.position, m_moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, m_targetLocation.rotation, m_moveSpeed * Time.deltaTime);
    }

    public void MainMenu()
    {
        m_targetLocation = m_mainMenu;
    }

    public void SettingsMenu()
    {
        m_targetLocation = m_settingsMenu;
    }

    public void TutorialMenu()
    {
        m_targetLocation = m_tutorialMenu;
    }
}
