using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat
{
    public float speed;
    public float health;
    public float attackDelay;
    public int burstSize;
    public float burstDelay;
    public float attackCoolDown;
    
    public EnemyStat(float speed, int health, float attackDelay,  int burstSize, float burstDelay, float attackCoolDown){
        this.speed = speed;
        this.health = health;
        this.attackDelay = attackDelay;
        this.burstSize = burstSize;
        this.burstDelay = burstDelay;
        this.attackCoolDown = attackCoolDown;
    }
}
