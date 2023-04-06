using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPull : EnemyBehaviour
{
    private void Update() {
        Pull();
    }

    private float gravity = -9.81f;
    private Vector3 velocity = Vector3.zero;
    private void Pull(){
        if(!enemy.isGrounded){
            transform.position += velocity*Time.deltaTime;
            velocity.y+=gravity*Time.deltaTime;
        }
        else if(enemy.isGrounded && velocity.y < 0){
            Land();
        }
    }

    private void Land(){
        velocity.y = -2f;
    }
}
