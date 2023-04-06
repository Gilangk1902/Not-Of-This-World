using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : EnemyBehaviour
{
    [SerializeField] Animator anim;
    void Update()
    {
        if(enemy.isMoving){
            anim.Play("Walk");
        }
        else if(enemy.isAttacking){
            anim.Play("Shoot");
        }
        else if(enemy.isReloading){
            anim.Play("Reload");
        }
        else{
            anim.Play("Idle");
        }
    }
}
