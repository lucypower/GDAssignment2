using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    Light m_light;
    [SerializeField] private GameObject m_roof;

    private void Awake()
    {
        m_light = GetComponentInChildren<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_light.enabled = true;
            m_roof.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_light.enabled = false;
            //m_roof.SetActive(true);
        }
    }
}
