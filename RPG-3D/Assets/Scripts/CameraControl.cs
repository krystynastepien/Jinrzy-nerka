using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 10.0f;    // minimalne nachylenie do podlogi
    private const float Y_ANGLE_MAX = 80.0f;    // maksymalne nachylenie do podlogi

    public Transform lookAt;
    private Transform camTransform;
    public float distance = 30.0f;

    private float currentX = 0.0f;
    private float currentY = 45.0f;
    private float sensitivityX = 8.0f;
    private float sensitivityY = 6.0f;



    private void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        camTransform = transform;
    }

    private void Update()
    {
        // Input.GetMouseButton(0) - registers every frame the mouse is down, 
        // Input.GetMouseButtonDown(0) - only registers on the first frame the user clicks.
        if (Input.GetMouseButton(1)) // obracaj kamere gdy wciśnięty prawy przycisk myszki
        {
            currentX += Input.GetAxis("Mouse X");
            currentY += Input.GetAxis("Mouse Y");
        }

        //scroll
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            //GetComponent<Camera>().fieldOfView = GetComponent<Camera>().fieldOfView - 2;
            distance--;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            //GetComponent<Camera>().fieldOfView = GetComponent<Camera>().fieldOfView + 2;
            distance++;
        }

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
       
            camTransform.position = lookAt.position + rotation * dir;  // poruszanie sie za postacia
            camTransform.LookAt(lookAt.position);   //kamera skierowana na postac
        
    }
}
