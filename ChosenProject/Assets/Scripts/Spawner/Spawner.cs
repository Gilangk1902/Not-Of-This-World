using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    bool playerInRadar;
    public LayerMask playerMask;
    public SpawnerData data;
    GameObject obj;
    int spawnCounter;

    void Start()
    {
        spawnCounter = 0;    
        obj = data.objectToSpawn;
    }
    void Update()
    {
        playerInRadar = Physics.CheckSphere(transform.position, data.radius, playerMask);

        if (playerInRadar && spawnCounter<data.maxNumOfSpawn)
        {
            Spawn();
            spawnCounter++;
        }
    }
    public void Spawn()
    {
        if (obj != null)
        {
            Instantiate(obj, transform.position, obj.transform.rotation);
        }
    }
}
