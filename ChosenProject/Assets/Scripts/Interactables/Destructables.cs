using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructables : MonoBehaviour
{
    [SerializeField] InteractablesData data;
    float health;
    private void Start() {
        health = data.health;
    }

    void Update(){
        if(health<=0){
            Instantiate(data.objToSpawn, transform.position, data.objToSpawn.transform.rotation);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage){
        health-=damage;
    }
}
