using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{   
    public static void Rotate(Vector3 target, Transform enemy){
        Vector3 direction = (target - enemy.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        enemy.rotation = Quaternion.Slerp(enemy.rotation, lookRotation, Time.deltaTime*2f);
    }
}
