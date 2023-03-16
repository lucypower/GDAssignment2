using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerController m_playerController;
    Rigidbody m_RB;
    
    private Vector3 m_moveInput;
    [SerializeField] private float m_speed;
    [SerializeField] private GameObject m_bullet;
    [SerializeField] private Transform m_bulletStart;

    private void Awake()
    {
        m_playerController = new PlayerController();

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

        if (m_playerController.Player.Shoot.WasPressedThisFrame())
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        Vector2 getInput = m_playerController.Player.Move.ReadValue<Vector2>();

        m_moveInput = new Vector3(getInput.x, 0, getInput.y);

        m_RB.velocity = m_moveInput * m_speed;
    }

    public void Shoot()
    {
        Instantiate(m_bullet, m_bulletStart.transform.position, Quaternion.identity);
    }

    private void OnDisable()
    {
        m_playerController.Player.Disable();
    }
}
