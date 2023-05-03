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
    private DoorController m_doorController;
    private GameObject m_parent;

    [SerializeField] private GameObject m_bullet;
    [SerializeField] private Transform m_bulletStart;

    public int m_chargeSpeed;
    public int m_radius;
    public int m_bulletSpeed;
    private bool m_hasCharged;

    //IEnumerator m_coroutine;

    private void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_player = GameObject.Find("Player");

        m_parent = transform.parent.gameObject;
        m_doorController = m_parent.GetComponentInChildren<DoorController>();

        //m_coroutine = ChargeReset(5);

        m_enemyStates = EnemyStates.IDLE;
    }

    private void Update()
    {
        switch (m_enemyStates)
        {
            case EnemyStates.CHARGING:

                //if (m_doorController.m_doorsActive)
                //{
                //    if (!m_hasCharged)
                //    {
                //        Charging();
                //    }
                //}

                if (!m_hasCharged)
                {
                    Charging();
                }

                break;

            case EnemyStates.SHOOTING:

                Shooting();

                break;

            case EnemyStates.IDLE:

                if (m_agent.remainingDistance <= 0.1f)
                {
                    int random = Random.Range(0, 2);

                    if (random == 0)
                    {
                        Idle();
                    }
                    else if (random == 1)
                    {
                        m_enemyStates = EnemyStates.SHOOTING;
                    }
                }

                break;

            default:
                break;
        }
    }

    private void Charging()
    {
        if (m_doorController.m_doorsActive)
        {
            m_hasCharged = true;

            m_agent.SetDestination(m_player.transform.position);
            m_agent.speed = m_chargeSpeed;

            m_enemyStates = EnemyStates.IDLE;
            StartCoroutine(ChargeReset(3));
        }
    }

    private void Shooting()
    {
        var bullet = Instantiate(m_bullet, m_bulletStart.transform.position, Quaternion.identity);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * m_bulletSpeed;

        Destroy(bullet, 2f);

        m_enemyStates = EnemyStates.IDLE;
    }

    private void Idle()
    {
        if (!m_hasCharged)
        {
            m_enemyStates = EnemyStates.CHARGING;
        }

        NavMeshHit hit;
        Vector3 direction = Random.insideUnitSphere * m_radius;
        direction += transform.position;

        float distFromPlayer = Vector3.Distance(transform.position, m_player.transform.position);

        NavMesh.SamplePosition(direction, out hit, Random.Range(0, m_radius), 1);

        m_agent.SetDestination(hit.position);
        m_agent.speed = 5f;
    }

    IEnumerator ChargeReset(float waitTime)
    {
        Debug.Log("Coroutine");
        yield return new WaitForSeconds(waitTime);

        m_hasCharged = false;
    }
}
