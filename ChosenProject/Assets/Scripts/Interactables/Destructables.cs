using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destructables : MonoBehaviour
{
    [SerializeField] InteractablesData data;
    [SerializeField] GameObject obj1;
    [SerializeField] GameObject obj2;

    float health;
    private void Start() {
        health = data.health;

    }

    void Update(){
        if(health<=0){
            SpawnRandomObj();
            Destroy(gameObject);
        }
    }
    public void SpawnRandomObj()
    {
        int index;
        index = Random.Range(0, 2);
        GameObject obj;

        if (index == 0)
        {
            obj = obj1;
        }
        else
        {
            obj = obj2;
        }
        Instantiate(obj, transform.position, transform.rotation);
    }

    public void TakeDamage(float damage){
        health-=damage;
    }
}
