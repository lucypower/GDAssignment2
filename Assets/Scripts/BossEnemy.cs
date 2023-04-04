using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class BossEnemy : MonoBehaviour
{
    public enum EnemyStates
    {
        CHARGING, SHOOTING, IDLE
    };

    public EnemyStates m_enemyStates;

    private NavMeshAgent m_agent;
    private GameObject m_player;

    public int m_chargeSpeed;
    public int m_radius;
    private bool m_hasCharged;
    IEnumerator m_coroutine;

    private void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_player = GameObject.Find("Player");

        m_coroutine = ChargeReset(5);
    }

    private void Update()
    {
        switch (m_enemyStates)
        {
            case EnemyStates.CHARGING:                

                Charging();

                break;

            case EnemyStates.SHOOTING:

                break;

            case EnemyStates.IDLE:

                Idle();

                if (m_coroutine == null)
                {
                    m_enemyStates = EnemyStates.CHARGING;
                }

                break;

            default:
                break;
        }
    }

    private void Charging()
    {
        m_agent.SetDestination(m_player.transform.position);
        m_agent.speed = m_chargeSpeed;

        if (m_agent.remainingDistance <= 0.1f)
        {
            StartCoroutine(ChargeReset(5));
            m_enemyStates = EnemyStates.IDLE;

        }


        //m_hasCharged = true;

        //StartCoroutine(ChargeReset(5));

    }

    private void Shooting()
    {

    }

    private void Idle()
    {
        NavMeshHit hit;
        Vector3 direction = Random.insideUnitSphere * m_radius;
        direction += transform.position;

        NavMesh.SamplePosition(direction, out hit, Random.Range(0, m_radius), 1);

        m_agent.SetDestination(hit.position);
        m_agent.speed = 5f;
    }

    IEnumerator ChargeReset(float waitTime)
    {
        Debug.Log("Coroutine");
        yield return new WaitForSeconds(waitTime);
    }
}
