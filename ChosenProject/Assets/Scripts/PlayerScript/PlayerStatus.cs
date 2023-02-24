using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : PlayerBehaviour
{
    public int health;
    public float speed;
    public float jumpHeight;
    public int maxJump;
    public PlayerData data;
    
    void Start()
    {
        health = data.health;
        speed = data.speed;
        jumpHeight = data.jumpHeight;
        maxJump = data.maxJump;
    }

    public void TakeDamage(int value){
        health-=value;
    }
}
