using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent m_agent;
    [SerializeField] private float m_radius;
    private float m_timer;

    private void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Wander();
    }

    public void Wander()
    {
        NavMeshHit hit;
        m_timer += Time.deltaTime;
        
        if (m_timer >= 2)
        {
            Vector3 direction = Random.insideUnitSphere * m_radius;
            direction += transform.position;

            NavMesh.SamplePosition(direction, out hit, m_radius, 0);

            m_agent.SetDestination(hit.position);

            m_timer = 0;
        }

    }
}
