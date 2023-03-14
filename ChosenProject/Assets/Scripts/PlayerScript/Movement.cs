using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : PlayerBehaviour
{
    public CharacterController controller;
    public int maxDash = 3;
    float timeSinceLastDash;
    private void Start() {
    }
    void Update()
    {
        timeSinceLastDash+=Time.deltaTime;
        if(!isDashing){
            PlayerMovement();
            Jump();
            Crouch();
        }
        Gravity();
        Dash();
        DashVelocity();

        if(timeSinceLastDash > 3){
            dashCount--;
            timeSinceLastDash = 0;
        }

        
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

    bool isDashing = false;
    int dashCount = 0;
    bool setAxisDashOnetime = false;
    Vector3 dashDirection;
    float dashCooldown = 2f;
    float dashSpeed = 100f;
    public void Dash(){
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(!isDashing){
            dashDirection = transform.right*x + transform.forward*z;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && dashCount < maxDash){
            if(dashDirection == Vector3.zero){
                dashDirection = transform.forward;
            }
            isDashing = true;
            dashCount++;
        }
        if(isDashing){
            controller.Move(dashDirection*dashSpeed*Time.deltaTime);
            //Invoke("DashStop", .1f);
            DashStop();
        }
    }

    void DashVelocity(){
        if(isDashing){
            if(dashSpeed<=100 && dashSpeed > 0){
                dashSpeed-=.5f;
            }
        }
        else{
            dashSpeed=80f;
        }
    }
    void DashStop(){
        if(dashSpeed <= 5f){
            isDashing = false;
            timeSinceLastDash = 0;
        }
    }

    public void Crouch(){
        if(Input.GetKeyDown(KeyCode.LeftControl)){
            controller.height = 2.5f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl)){
            controller.height = 4;
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
