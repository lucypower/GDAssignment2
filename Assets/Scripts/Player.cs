using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerController m_playerController;
    Rigidbody m_RB;
    
    private Vector3 m_moveInput;
    [SerializeField] private float m_speed;

    private void Awake()
    {
        m_playerController = new PlayerController();

        m_RB = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        m_playerController.Player.Enable();
    }

    private void OnDisable()
    {
        m_playerController.Player.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 getInput = m_playerController.Player.Move.ReadValue<Vector2>();

        m_moveInput = new Vector3(getInput.x, 0, getInput.y);

        m_RB.velocity = m_moveInput * m_speed;
    }
}
