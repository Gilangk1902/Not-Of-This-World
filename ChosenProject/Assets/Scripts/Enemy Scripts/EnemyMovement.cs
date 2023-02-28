using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : EnemyBehaviour
{
    public Vector3 runTo;
    public Transform playerLocation;
    Vector3 lastSeenPlayerLocation;
    Vector3 randomRunTo;
    public NavMeshAgent agent;
    public bool isMoving;
    
    void Start()
    {
        runTo = transform.position;
        playerLocation = GameObject.Find("Player").transform;
        agent.speed = enemy.data.movementSpeed;
    }
    void Update()
    {
        FindPlayerLocation();
        Gravity();
        if(enemy.radar.inAttackRange){
            agent.destination = transform.position;
            enemy.anim.PlayIdle();
        }
        else{
            if(!enemy.attack.isAttacking){
                WalkTo();
            }
            else if(enemy.attack.isAttacking){
                agent.destination = transform.position;
                enemy.anim.PlayIdle();
            }
        }
    }
    public void WalkTo()
    {
        if (enemy.provoked)
        {
            runTo = playerLocation.position;
            agent.destination = runTo;
            enemy.anim.PlayWalk();
        }
        else{
            runTo = transform.position;
            agent.destination = runTo;
            enemy.anim.PlayIdle();
        }
    }
    public void SetRandomPosition()
    {
        float x, y, z;
        x = Random.Range(-10, 10);
        y = Random.Range(-10, 10);
        z = Random.Range(-10, 10);

        randomRunTo = new Vector3(x,0,z);
        runTo = randomRunTo;
    }
    
    public void FindPlayerLocation()
    {
        if (enemy.spotPlayer)
        {
            lastSeenPlayerLocation = playerLocation.position;
        }
    }

    Vector3 velocity;
    float gravity = -9.807f;
    void Gravity()
    {
        if (!agent.enabled && !enemy.isGrounded)
        {
            velocity.y += gravity/4 * Time.deltaTime;
            transform.position += new Vector3(0, velocity.y, 0);
        }
        else if (enemy.isGrounded)
        {
            velocity.y = 0f;
            agent.enabled = true;
        }
    }
}
