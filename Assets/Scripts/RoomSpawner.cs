using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    RoomManager m_roomManager;
    GameManager m_gameManager;

    [HideInInspector] public bool m_roomSpawned;
    public char m_roomDir;

    private void Awake()
    {
        m_roomManager = GameObject.Find("RoomManager").GetComponent<RoomManager>();
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        Invoke("SpawnRoom", 0.1f);
    }

    public void SpawnRoom()
    {
        if (!m_roomSpawned)
        {
            if (m_gameManager.m_roomCount < m_gameManager.m_roomsAllowed)
            {
                switch (m_roomDir)
                {
                    case 't':

                        Instantiate(m_roomManager.m_bottom[Random.Range(0, m_roomManager.m_bottom.Length)], transform.position, Quaternion.identity);
                        m_roomSpawned = true;
                        m_gameManager.m_roomCount++;
                        break;

                    case 'b':

                        Instantiate(m_roomManager.m_top[Random.Range(0, m_roomManager.m_top.Length)], transform.position, Quaternion.identity);
                        m_roomSpawned = true;
                        m_gameManager.m_roomCount++;
                        break;

                    case 'l':

                        Instantiate(m_roomManager.m_right[Random.Range(0, m_roomManager.m_right.Length)], transform.position, Quaternion.identity);
                        m_roomSpawned = true;
                        m_gameManager.m_roomCount++;
                        break;

                    case 'r':

                        Instantiate(m_roomManager.m_left[Random.Range(0, m_roomManager.m_left.Length)], transform.position, Quaternion.identity);
                        m_roomSpawned = true;
                        m_gameManager.m_roomCount++;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Instantiate(m_roomManager.m_end, transform.position, Quaternion.identity);
                m_roomSpawned = true;
            }
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            RoomSpawner room = other.GetComponent<RoomSpawner>();

            if (room != null)
            {
                if (!room.m_roomSpawned && !m_roomSpawned)
                {
                    Instantiate(m_roomManager.m_end, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }            

            m_roomSpawned = true;
        }
    } 
}
