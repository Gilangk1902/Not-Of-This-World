using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : EnemyBehaviour
{
    public float rotationSpeed;
    private Quaternion lookRotation;
    private Vector3 direction;
    public bool allowChangeRotation;
    public float timeSinceLastSeenPlayer;
    void Start(){
        allowChangeRotation = true;
        timeSinceLastSeenPlayer = 0;
    }
    void Update()
    {
        timeSinceLastSeenPlayer += Time.deltaTime;
        
        
        Vision();
        if(enemy.radar.inSpotRange || enemy.provoked){
            LookAt(enemy.movement.playerLocation.position);
        }
        if(timeSinceLastSeenPlayer>3f){
            enemy.provoked = false;
        }
    }
    
    public void Vision()
    {
        RaycastHit hitInfo;
        enemy.spotPlayer = Physics.SphereCast(enemy.eye.position, 2, transform.forward, out hitInfo, enemy.data.visionRange, enemy.playerMask);
        if (enemy.spotPlayer)
        {
            enemy.provoked = true;
            timeSinceLastSeenPlayer = 0f;
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


    bool randomIsSet = false;
    public void RandomScanForPlayer(){
        Quaternion lookRotation = new Quaternion();
        if(timeSinceLastSeenPlayer >= 3f){
            if(!randomIsSet){
                lookRotation = SetRandomRotation();
                randomIsSet = true;
            }   
            else{
                Invoke("ResetRandomIsSet", 1.5f);
            }
            LookAt(lookRotation);
        }
    }
    private void ResetRandomIsSet(){
        randomIsSet = false;
    }
}
