using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : PlayerBehaviour
{
    public CharacterController controller;
    
    void Update()
    {
        PlayerMovement();
        Jump();
        Gravity();
        Sprint();
        Crouch();
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

    public void Sprint(){
        if(Input.GetButtonDown("Sprint")){
            player.status.speed = player.status.speed*2.4f;
        }
        else if(Input.GetButtonUp("Sprint")){
            player.status.speed = player.status.data.speed;
        }
    }

    public void Crouch(){
        if(Input.GetKeyDown(KeyCode.LeftControl)){
            transform.localScale = new Vector3(0.5f,0.5f, 0.5f);
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl)){
            transform.localScale = new Vector3(1,1f, 1);
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
