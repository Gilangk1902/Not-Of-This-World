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
    public EnemyVision vision;
    public EnemyRadar radar;

    void Awake()
    {
        movement.enemy = this;
        provoked = false;
        vision.enemy = this;
        radar.enemy = this;
    }
    void Update()
    {
        
    }
    
}
 public abstract class EnemyBehaviour : MonoBehaviour
{
    [HideInInspector] public Enemy enemy;
}
