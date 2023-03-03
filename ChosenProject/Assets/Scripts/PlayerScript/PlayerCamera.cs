using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : PlayerBehaviour
{
    public GameObject camera;
    public bool enable;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        enable = true;
    }
    void Update()
    {
        if (enable)
        {
            CameraMovement();
        }
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

    public void CameraLockedOnTarget(Vector3 Target)
    {
        Vector3 direction;
        direction = (Target-transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*lookSensitivity*5);
    }
}
