using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy", menuName ="Enemy/Data")]
public class EnemyData : ScriptableObject
{
    public float visionRange;
    public int damage;
    public float health;
    public float coolDownAttk;
    public float armor;
    public float movementSpeed;
    public float numOfAttackPerAtk;
    public float delayBetweenAtk;

}
