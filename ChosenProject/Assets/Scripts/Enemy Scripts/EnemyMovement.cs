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
        agent.speed = enemy.data.movementSpeed;
    }
    void Update()
    {
        FindPlayerLocation();
        
        if(enemy.radar.inAttackRange){
            agent.destination = transform.position;
            enemy.anim.PlayIdle();
        }
        else{
            WalkTo();
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

    
}
