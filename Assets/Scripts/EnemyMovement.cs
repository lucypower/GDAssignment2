using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent m_agent;
    private GameObject m_player;

    [SerializeField] private float m_radius;
    [SerializeField] private float m_followRadius;

    // check nav mesh cause sometimes they half go in a wall
    // need to add stuff like damage in another script

    private void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_player = GameObject.Find("Player");
    }

    private void Start()
    {
        Wander();
    }

    private void Update()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, m_player.transform.position);

        if (distanceFromPlayer <= m_followRadius)
        {
            FollowPlayer();
        }

        if (m_agent.remainingDistance <= 0.1f)
        {
            Wander();
        }
    }

    public void Wander()
    {
        NavMeshHit hit;
        Vector3 direction = Random.insideUnitSphere * m_radius;
        direction += transform.position;

        NavMesh.SamplePosition(direction, out hit, Random.Range(0, m_radius), 1);

        m_agent.SetDestination(hit.position);
        m_agent.speed = 5f;
    }

    public void FollowPlayer()
    {
        m_agent.SetDestination(m_player.transform.position);
        m_agent.speed = 8f;
    }
}
