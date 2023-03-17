using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody m_RB;

    private void Awake()
    {
        m_RB = GetComponent<Rigidbody>();
    }

    public void Fire(float speed, Vector3 direction)
    {
        m_RB.velocity = (speed * direction);        
    }
}
