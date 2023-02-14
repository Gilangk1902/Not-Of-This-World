using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : PlayerBehaviour
{
    public GameObject camera;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
        void Update()
    {
        CameraMovement();
    }

    public float lookSensitivity;
    float xRotation = 0f;
    public float maxRotationUpward = 90f;
    public float maxRotationDownward = 90f;
    void CameraMovement(){
        transform.Rotate(0, Input.GetAxis("Mouse X") * lookSensitivity, 0);
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        xRotation = Mathf.Clamp(xRotation, -maxRotationUpward, maxRotationDownward);

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
