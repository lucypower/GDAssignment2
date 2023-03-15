using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{    
    private bool m_collision;
    CameraController m_cameraController;

    private void Awake()
    {
        m_cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    private void Update()
    {
        if (m_collision)
        {
            m_cameraController.MoveCamera();
        }
    }    

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_collision = true;
        }
    }
}
