using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRoomSpawner : MonoBehaviour
{
    RoomManager m_roomManager;

    [HideInInspector] public bool m_roomSpawned = false;

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
            Instantiate(m_roomManager.m_end, transform.position, Quaternion.identity);
            m_roomSpawned = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
            m_roomSpawned = true;
        }
    }
}
