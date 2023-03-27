using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public int m_floorNo;
    [HideInInspector] public int m_roomsAllowed;
    [HideInInspector] public int m_roomCount;

    private void Start()
    {
        m_roomCount = 0;
        m_roomsAllowed = ((3 * m_floorNo) + Random.Range(4, 6));
    }
}
