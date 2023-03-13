using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script of arrays to keep track of room entrances

public class RoomManager : MonoBehaviour
{
    public GameObject[] m_top, m_bottom, m_left, m_right;
    public GameObject m_end;

    public List<GameObject> m_deadEndRooms;
}
