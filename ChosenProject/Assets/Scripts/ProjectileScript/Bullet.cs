using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //bullet data
    public LayerMask playerMask;
    public BulletData data;
    
    public bool hasHit;


    public void Awake() {
        hasHit = false;
    }
    public void Update() {
        Travel();
        ColliderChecker();
    }

    public void Travel(){
        transform.position += transform.forward*data.speed*Time.deltaTime;
    }

    public void ColliderChecker(){
        Collider[] hit = Physics.OverlapSphere(transform.position, data.hitRadius, playerMask);
        for(int i=0;i<hit.Length;i++){
            if(hit[i].gameObject.layer == 6 && !hasHit){
                hit[i].GetComponent<PlayerStatus>().TakeDamage(data.damage);
                hasHit = true;
                Destroy(gameObject);
            }
        }
    }
}

public abstract class BulletBehaviour : MonoBehaviour{
    Bullet bullet;
}
