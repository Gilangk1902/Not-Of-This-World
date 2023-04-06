using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public static void MoveForward(Transform enemy, float speed){
        enemy.position += enemy.forward*speed*Time.deltaTime;
    }

    public static void MoveTo(NavMeshAgent agent, Vector3 target, float speed){
        agent.speed = speed;
        agent.destination = target;
    }

    public static void StandStill(NavMeshAgent agent ,Transform enemy){
        agent.destination = enemy.position;
    }
}
