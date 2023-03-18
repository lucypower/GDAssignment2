using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject[] m_doors;
    //[SerializeField] private GameObject m_lighting;

    EnemyManager m_enemyManager;

    private void Awake()
    {
        m_enemyManager = gameObject.GetComponentInParent<EnemyManager>();        
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
                }
            }
            else
            {
                for (int i = 0; i < m_doors.Length; i++)
                {
                    m_doors[i].SetActive(false);
                }
            }
        }
    }
}
