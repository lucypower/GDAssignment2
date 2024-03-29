using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject[] m_doors;
    public bool m_doorsActive;

    EnemyManager m_enemyManager;

    private void Awake()
    {
        m_enemyManager = gameObject.GetComponentInParent<EnemyManager>();
        m_doorsActive = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {         
            if (m_enemyManager.m_enemiesAlive)
            {
                for (int i = 0; i < m_doors.Length; i++)
                {
                    m_doors[i].SetActive(true);
                    m_doorsActive = true;
                }
            }
            else
            {
                for (int i = 0; i < m_doors.Length; i++)
                {
                    m_doors[i].SetActive(false);
                    m_doorsActive = false;
                }
            }
        }
    }
}
