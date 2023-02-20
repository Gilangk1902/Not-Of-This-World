using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : EnemyBehaviour
{
    void Update()
    {
        
    }

    public void TakeDamage(float damage){
        enemy.health -= damage;
    }
}
