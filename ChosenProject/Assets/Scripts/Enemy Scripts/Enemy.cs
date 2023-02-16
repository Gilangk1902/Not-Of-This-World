using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform eye;
    public bool spotPlayer;
    public bool provoked;
    public LayerMask playerMask;

    public EnemyMovement movement;

    void Awake()
    {
        movement.enemy = this;
    }
    void Update()
    {
        Vision();
        if (spotPlayer)
        {
            provoked = true;
        }
    }
    public void Vision()
    {
        spotPlayer = Physics.Raycast(eye.position, transform.forward, 5f, playerMask);
    }
}
 public abstract class EnemyBehaviour : MonoBehaviour
{
    [HideInInspector] public Enemy enemy;
}
