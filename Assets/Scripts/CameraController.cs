using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField] private GameObject m_player;


    public GameObject FindClosestCamera()
    {
        GameObject[] cameraLocations;
        cameraLocations = GameObject.FindGameObjectsWithTag("CameraLocation");


        GameObject closestLocation = null;
        float distance = Mathf.Infinity;

        foreach (GameObject location in cameraLocations)
        {
            Vector3 difference = location.transform.position - m_player.transform.position;
            float curDistance = difference.sqrMagnitude;

            if (curDistance < distance)
            {
                closestLocation = location;
                distance = curDistance;
            }
        }

        return closestLocation;
    }


    public void MoveCamera()
    {
        Vector3 targetLocation = FindClosestCamera().transform.position;

        transform.position = Vector3.Lerp(transform.position, targetLocation, 4 * Time.deltaTime);
    }




    //[SerializeField] private Transform m_originalLocation;

    //public void MoveCamera(Vector3 coords)
    //{        
    //    transform.position = Vector3.Lerp(transform.position, transform.position + coords, 4 * Time.deltaTime);
    //}
}
