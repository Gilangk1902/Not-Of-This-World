using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Spawner", menuName ="Spawner/Data")]

public class SpawnerData : ScriptableObject
{
    public GameObject objectToSpawn;
    public int maxNumOfSpawn;
    public float radius;
}
