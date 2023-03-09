using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsInteractibles : MonoBehaviour
{
    bool isGrounded;
    [SerializeField] private LayerMask groundMask;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, .2f, groundMask);
        Gravity();
    }
    Vector3 velocity;
    private void Gravity()
    {
        if (!isGrounded)
        {
            velocity += Physics.gravity/2 * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
        }
        else
        {
            velocity = Vector3.zero;
            transform.position += velocity * Time.deltaTime;
            transform.rotation = new Quaternion(0, transform.rotation.y, 0, 0);
        }
    }
}
