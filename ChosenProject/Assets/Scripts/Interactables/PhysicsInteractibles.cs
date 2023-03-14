using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsInteractibles : MonoBehaviour
{
    bool isGrounded;
    public bool isHold = false;
    [SerializeField] private LayerMask groundMask;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, .2f, groundMask);
        Gravity();
    }
    Vector3 velocity;
    private void Gravity()
    {
        if (!isGrounded && !isHold)
        {
            velocity += Physics.gravity * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
        }
        else if(isGrounded)
        {
            velocity = Vector3.zero;
            transform.position += velocity * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0,transform.eulerAngles.y, 0);
        }
    }
}
