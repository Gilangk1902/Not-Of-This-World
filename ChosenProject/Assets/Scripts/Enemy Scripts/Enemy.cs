using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform eye;
    public Transform feet;
    public bool spotPlayer;
    public bool provoked;
    public bool isGrounded;
    public float health;
    public LayerMask groundMask;
    public LayerMask playerMask;

    public EnemyData data;
    public EnemyMovement movement;
    public EnemyVision vision;
    public EnemyRadar radar;
    public EnemyAnimator anim;
    public EnemyStatus status;
    public EnemyAttack attack;

    void Awake()
    {
        movement.enemy = this;
        provoked = false;
        vision.enemy = this;
        radar.enemy = this;
        anim.enemy = this;
        health = 100f;
        status.enemy = this;
        attack.enemy = this;
        movement.agent.enabled = false;
        isGrounded = false;
    }
    void Update()
    {
        Die();
        isGrounded = Physics.CheckSphere(feet.position, .4f, groundMask);
    }

    void Die(){
        if(health <= 0f){
            Destroy(gameObject);
        }
    }

    
}
 public abstract class EnemyBehaviour : MonoBehaviour
{
    [HideInInspector] public Enemy enemy;
}
