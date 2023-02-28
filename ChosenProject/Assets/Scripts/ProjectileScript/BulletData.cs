using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Bullet", menuName = "Bullet/Data")]
public class BulletData : ScriptableObject
{
    public float speed;
    public int damage;
    public float hitRadius;    
}
