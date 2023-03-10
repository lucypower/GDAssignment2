using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    RoomManager m_roomManager;

    public char m_roomDir;
    [SerializeField] public bool m_roomSpawned;

    private void Awake()
    {
        m_roomManager = GameObject.Find("RoomManager").GetComponent<RoomManager>();
    }

    private void Start()
    {
        Invoke("SpawnRoom", 0.1f);
    }

    public void SpawnRoom()
    {
        if (!m_roomSpawned)
        {
            switch (m_roomDir)
            {
                case 't':

                    Instantiate(m_roomManager.m_bottom[Random.Range(0, m_roomManager.m_bottom.Length)], transform.position, Quaternion.identity);
                    m_roomSpawned = true;
                    break;

                case 'b':

                    Instantiate(m_roomManager.m_top[Random.Range(0, m_roomManager.m_top.Length)], transform.position, Quaternion.identity);
                    m_roomSpawned = true;
                    break;

                case 'l':

                    Instantiate(m_roomManager.m_right[Random.Range(0, m_roomManager.m_right.Length)], transform.position, Quaternion.identity);
                    m_roomSpawned = true;
                    break;

                case 'r':

                    Instantiate(m_roomManager.m_left[Random.Range(0, m_roomManager.m_left.Length)], transform.position, Quaternion.identity);
                    m_roomSpawned = true;
                    break;

                case 'c':

                    m_roomSpawned = true;
                    break;

                default:
                    break;
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
