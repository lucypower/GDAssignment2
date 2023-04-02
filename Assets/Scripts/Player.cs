using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerController m_playerController;
    PlayerStats m_playerStats;
    Rigidbody m_RB;
    
    private Vector3 m_moveInput;

    private float m_speed;
    private float m_projectileSpeed; 

    [SerializeField] private GameObject m_bullet;
    [SerializeField] private Transform m_bulletStart;

    private bool m_isShooting;
    

    private void Awake()
    {
        m_playerController = new PlayerController();
        m_playerStats = GetComponent<PlayerStats>();

        m_RB = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        m_playerController.Player.Enable();
    }

    private void Update()
    {
        Vector3 mousePosition = m_playerController.Player.Rotation.ReadValue<Vector2>();
        var direction = mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(-angle + 90, Vector3.up);

        if (m_playerController.Player.Shoot.IsPressed())
        {
            if (!m_isShooting)
            {
                Shoot();
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 getInput = m_playerController.Player.Move.ReadValue<Vector2>();

        m_moveInput = new Vector3(getInput.x, 0, getInput.y);
        m_speed = PlayerPrefs.GetInt("WalkSpeed");

        m_RB.velocity = m_moveInput * m_speed;
    }

    public void Shoot()
    {
        m_isShooting = true;

        var bullet = Instantiate(m_bullet, m_bulletStart.transform.position, Quaternion.identity);

        m_projectileSpeed = PlayerPrefs.GetInt(m_playerStats.m_playerRange);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = m_projectileSpeed * transform.forward;

        int time = PlayerPrefs.GetInt(m_playerStats.m_playerBPS);
        StartCoroutine(ShootingDelay(time));

        Destroy(bullet, 1f);
    }

    IEnumerator ShootingDelay(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        m_isShooting = false;
    }

    private void OnDisable()
    {
        m_playerController.Player.Disable();
    }
}
