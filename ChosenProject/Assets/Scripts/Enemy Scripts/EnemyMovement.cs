using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyBehaviour
{
    Transform runTo;
    public Transform playerLocation;
    Transform lastSeenPlayerLocation;
    Vector3 randomRunTo;
    void Start()
    {
        runTo.position = transform.position;    
    }
    void Update()
    {
        FindPlayerLocation();
        WalkTo(5f);
    }
    public void WalkTo(float speed)
    {
        if (enemy.provoked)
        {
            runTo.position = lastSeenPlayerLocation.position;
            gameObject.transform.position = runTo.position;
        }
        else
        {
            if(transform.position == runTo.position)
            {
                Invoke("SetRandomPosition", 3f);
            }
            else
            {
                gameObject.transform.position = runTo.position;
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
        runTo.position = randomRunTo;
    }
    
    public void FindPlayerLocation()
    {
        if (enemy.spotPlayer)
        {
            lastSeenPlayerLocation.position = playerLocation.position;
        }
    }
}
