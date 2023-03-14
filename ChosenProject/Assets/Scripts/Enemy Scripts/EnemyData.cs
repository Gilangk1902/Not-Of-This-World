using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy", menuName ="Enemy/Data")]
public class EnemyData : ScriptableObject
{
    public float visionRange;
    public float inChaseRange;
    public float inAttackRange;
    public float inSpotRange;
    public int damage;
    public float health;
    public float movementSpeed;
    public float coolDownAttk;
    public float burstSize;
    public float burstDelay;
    public float delayAtk;
    public string type;
    public GameObject bullet;

    public int magSize;
    public int ammo;
    public float reloadTime;

}
