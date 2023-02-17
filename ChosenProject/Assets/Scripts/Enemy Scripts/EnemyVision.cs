using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : EnemyBehaviour
{
    public float rotationSpeed;
    private Quaternion lookRotation;
    private Vector3 direction;
    public float visionDistance;
    public bool allowChangeRotation;
    void Start(){
        allowChangeRotation = true;
    }
    void Update()
    {
        Vision();
        if(enemy.provoked){
            LookAt(enemy.movement.playerLocation.position);
        }
        else{
            
        }
    }
    
    public void Vision()
    {
        enemy.spotPlayer = Physics.Raycast(enemy.eye.position, transform.forward, visionDistance, enemy.playerMask);
        if (enemy.spotPlayer)
        {
            enemy.provoked = true;
        }
    }

    public void LookAt(Vector3 Target){
        direction = (Target - transform.position).normalized;
        lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*rotationSpeed);
    }
    public void LookAt(Quaternion rotation){
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime*rotationSpeed);
    }
    public Quaternion SetRandomRotation(){
        float x,y,z;
        x = Random.Range(-180,180);
        y = Random.Range(-180,180);
        z = Random.Range(-180,180);
        return new Quaternion(0,y,0,1);
    }

    
}
