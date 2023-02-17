using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : EnemyBehaviour
{
    public bool inChaseRange;
    public bool inAttackRange;

    void Update(){
        inChaseRange = Physics.CheckSphere(transform.position, 15f, enemy.playerMask);
        inAttackRange = Physics.CheckSphere(transform.position, 5f, enemy.playerMask);
    }
}
