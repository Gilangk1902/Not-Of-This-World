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

    public void CameraLockedOnTargetVertical(Vector3 Target)
    {
        camera.transform.LookAt(Target);

        Vector3 eulerAngles = camera.transform.rotation.eulerAngles;
        eulerAngles.y = 0;
        eulerAngles.z = 0;

        camera.transform.localRotation = Quaternion.Euler(eulerAngles);
    }

    public void CameraLockedOnTargetHorizontal(Vector3 Target){
        transform.LookAt(Target);

        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles.x = 0;
        eulerAngles.z = 0;

        transform.rotation = Quaternion.Euler(eulerAngles);
    }
}
