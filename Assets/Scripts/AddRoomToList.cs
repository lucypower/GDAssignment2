using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AddRoomToList : MonoBehaviour
{
    RoomManager m_roomManager;

    private void Awake()
    {
        m_roomManager = GameObject.Find("RoomManager").GetComponent<RoomManager>();
    }

    private void Start()
    {
        m_roomManager.m_rooms.Add(transform.root.gameObject);
    }
}