using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrapdoor : MonoBehaviour
{
    [SerializeField] private GameObject m_trapdoor;

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
                m_trapdoor.SetActive(false);
            }
            else
            {
                m_trapdoor.SetActive(true);
            }
        }
    }
}
