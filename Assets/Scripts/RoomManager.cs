using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// script of arrays to keep track of room entrances

public class RoomManager : MonoBehaviour
{
    public GameObject[] m_top, m_bottom, m_left, m_right;
    public GameObject m_end, m_boss, m_item;

    public List<GameObject> m_rooms;

    private void Start()
    {
        Invoke("SpawnBoss", 1.0f);
        Invoke("SpawnItem", 1.1f);
    }

    public void SpawnBoss()
    {
        var bossRoom = m_rooms.Last();

        Instantiate(m_boss, bossRoom.transform.position, Quaternion.identity);
        Destroy(bossRoom.gameObject);
        m_rooms.Remove(bossRoom);
    }

    public void SpawnItem()
    {
        var itemRoom = m_rooms.Last();

        Instantiate(m_item, itemRoom.transform.position, Quaternion.identity);
        Destroy(itemRoom.gameObject);
        m_rooms.Remove(itemRoom);
    }
}
