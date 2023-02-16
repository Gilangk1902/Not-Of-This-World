using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : PlayerBehaviour
{
    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Jump();
        Gravity();
        
    }
    
    Vector3 moveVelocity;
    public void PlayerMovement(){
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        moveVelocity = transform.right*x + transform.forward*z;
        if(x!=0 && z!=0){
            controller.Move(moveVelocity*player.status.speed*Time.deltaTime);
        }
        else if((x==0 || z == 0) && !(x!=0 && z!=0)){
            controller.Move(moveVelocity*player.status.speed*Time.deltaTime);
        }
    }
    public Vector3 jumpVelocity;
    public float gravity = -9.81f;
    int currentJump = 0;
    public void Jump(){
        if(currentJump<player.status.maxJump && Input.GetButtonDown("Jump")){
            currentJump++;
            jumpVelocity.y = player.status.jumpHeight;
        }
    }

    public LayerMask groundMask;
    
    public void Gravity(){
        if(player.isGrounded && jumpVelocity.y < 0){
            Land();
        }
        jumpVelocity.y += gravity*Time.deltaTime;
        controller.Move(jumpVelocity*Time.deltaTime);
    }
    public void Land(){
        jumpVelocity.y = -2f;
        currentJump = 0;
    }
}
