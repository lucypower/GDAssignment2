using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] private GameObject[] m_items;
    private bool m_itemSpawned = false;

    private void Start()
    {
        SpawnItems();
    }

    private void SpawnItems()
    {
        if (!m_itemSpawned)
        {
            Instantiate(m_items[Random.Range(0, m_items.Length)], transform.position, Quaternion.identity);
            m_itemSpawned = true;
        }
    }
}
