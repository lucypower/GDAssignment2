using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [HideInInspector] public float m_health;

    private void Start()
    {
        m_health = 100f;
    }
}
