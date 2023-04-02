using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public int m_floorNo;
    [HideInInspector] public int m_roomsAllowed;
    [HideInInspector] public int m_roomCount;

    [HideInInspector] public string m_floorNumber = "FloorNumber";

    private void Start()
    {
        if (!PlayerPrefs.HasKey(m_floorNumber))
        {
            PlayerPrefs.SetInt(m_floorNumber, 1);
        }

        int currentFloor = PlayerPrefs.GetInt(m_floorNumber);
        m_roomCount = 0;
        m_roomsAllowed = ((3 * currentFloor) + Random.Range(4, 6));
    }
}
