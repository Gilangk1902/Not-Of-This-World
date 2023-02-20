using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : EnemyBehaviour
{
    public Animator anim;
    void Main(){
        
    }

    public void PlayWalk(){
        anim.SetBool("walk",true);
    }
    public void PlayIdle(){
        anim.SetBool("walk",false);
    }
}
