using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> m_enemies;
    public bool m_enemiesAlive;

    private void Update()
    {
        //for (int i = 0; i < m_enemies.Length; i++)
        //{
        //    if (m_enemies[i].activeInHierarchy)
        //    {
        //        m_enemiesAlive = true;
        //    }
        //    else
        //    {
        //        m_enemiesAlive = false;
        //        break;
        //    }
        //}

        CheckEnemiesAlive();
    }

    public void CheckEnemiesAlive()
    {
        if (m_enemies.Count == 0)
        {
            m_enemiesAlive = false;
        }
        else
        {
            m_enemiesAlive = true;
        }
    }
}
