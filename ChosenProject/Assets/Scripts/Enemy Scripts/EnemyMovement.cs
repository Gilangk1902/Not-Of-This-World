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
    
    void Start()
    {
        runTo = transform.position;    
    }
    void Update()
    {
        FindPlayerLocation();
        if(enemy.radar.inChaseRange && !enemy.radar.inAttackRange){
            WalkTo();
        }
        else if(enemy.radar.inAttackRange){
            agent.destination = transform.position;
        }
    }
    public void WalkTo()
    {
        if (enemy.provoked)
        {
            runTo = lastSeenPlayerLocation;
            agent.destination = runTo;
        }
        else
        {
            if(transform.position == runTo)
            {
                Invoke("SetRandomPosition", 3f);
            }
            else
            {
                agent.destination = runTo;
            }
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
