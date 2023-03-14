using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : EnemyBehaviour
{
    public Animator anim;
    void Main(){
        if(enemy.movement.isMoving && !enemy.attack.isAttacking && !enemy.attack.isReloading){
            anim.Play("Walk");
        }
        else if(!enemy.movement.isMoving && enemy.attack.isAttacking && !enemy.attack.isReloading){
            anim.Play("Shoot");
        }
        else if(!enemy.movement.isMoving && !enemy.attack.isAttacking && !enemy.attack.isReloading){
            anim.Play("Idle");
        }
    }

    
}
