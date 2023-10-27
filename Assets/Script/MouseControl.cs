using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public float rotationSpeed = 5.0f;

    void Update()
    {
       
        float mouseX = Input.GetAxis("Mouse X");

       
        transform.Rotate(Vector3.forward * mouseX * rotationSpeed);
    }
}
