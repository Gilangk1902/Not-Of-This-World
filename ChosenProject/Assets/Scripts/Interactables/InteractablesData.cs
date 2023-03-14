using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Interactables", menuName = "Interactables/data")]
public class InteractablesData : ScriptableObject
{
    public int health;

    public string type;
    public float value;

    public GameObject objToSpawn;
}
