using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsInteractibles : MonoBehaviour
{
    bool isGrounded;
    public bool isHold = false;
    [SerializeField] Collider myCollider;
    [SerializeField] Collider otherCollider;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private LayerMask playerMask;
    public int num_of_holds;

    private void Start() {
        myCollider = GetComponent<Collider>();
        otherCollider = GameObject.Find("Player").GetComponent<CharacterController>();
        Physics.IgnoreCollision(myCollider, otherCollider);
        num_of_holds = 1;
    }
    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, .2f, groundMask);
        Gravity();
        PushForward();
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

    private void PushForward(){
        if(!isGrounded && !isHold & num_of_holds!=0){
            transform.position+=transform.forward*5f*Time.deltaTime;
        }
        else{
            return;
        }
    }
}
