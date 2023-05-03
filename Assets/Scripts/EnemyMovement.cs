using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent m_agent;
    private GameObject m_player;
    private DoorController m_doorController;

    GameObject m_parent;

    private string m_enemyType;

    [SerializeField] private float m_radius;
    [SerializeField] private float m_followRadius;
    [SerializeField] private float m_runAwayRadius;

    private void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_player = GameObject.Find("Player");
        m_enemyType = gameObject.tag;

        m_parent = transform.root.gameObject;
        m_doorController = m_parent.GetComponentInChildren<DoorController>();
    }

    private void Start()
    {
        Wander();
    }

    private void Update()
    {
        if (m_doorController.m_doorsActive)
        {
            switch (m_enemyType)
            {
                case "FollowPlayer":

                    float distanceFromPlayer = Vector3.Distance(transform.position, m_player.transform.position);

                    if (distanceFromPlayer <= m_followRadius)
                    {
                        FollowPlayer();
                    }

                    if (m_agent.remainingDistance <= 0.1f)
                    {
                        Wander();
                    }

                    break;

                case "RunFromPlayer":

                    float distFromPlayer = Vector3.Distance(transform.position, m_player.transform.position);

                    if (distFromPlayer <= m_runAwayRadius)
                    {
                        RunAway();
                    }

                    if (m_agent.remainingDistance <= 0.1f)
                    {
                        Wander();
                    }

                    break;

                case "RandomMove":

                    if (m_agent.remainingDistance <= 0.1f)
                    {
                        Wander();
                    }

                    break;

                default:
                    break;
            }
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

    public void RunAway()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - m_player.transform.position);
        Vector3 destination = transform.position + transform.forward;

        NavMesh.SamplePosition(destination, out NavMeshHit hit, m_radius, 1);

        m_agent.SetDestination(hit.position);
        m_agent.speed = 10f;
    }
}
