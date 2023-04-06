using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : EnemyBehaviour
{
    public int health;
    private void Start() {
        health = (int)enemy.stat.health;
    }

    public void TakeDamage(int val){
        health -= val;
    }
}
