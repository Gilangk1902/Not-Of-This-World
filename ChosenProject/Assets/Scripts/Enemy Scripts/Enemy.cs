using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public EnemyStat stat;
    public EnemyInventory inventory;
    public GravityPull gravityPull;
    public EnemyAi AI;
    public EnemyAnim anim;
    public EnemyStatus status;
    [SerializeField] private EnemyData data;

    public bool isGrounded;
    public bool isSpotPlayer;
    public bool isAgitated;
    public bool inAttackrange;
    public bool inChaseRange;
    public bool isMoving = false;
    public bool isAttacking = false;
    public bool hasAttack = false;
    public bool isReloading = false;

    public float timeSinceLastAttack = 0f;

    public Transform feet;
    public Transform atkTransform;
    public LayerMask groundMask;
    public LayerMask playerMask;
    public NavMeshAgent agent;

    public GameObject player;
    public GameObject atkObj;
    private void Awake() {
        gravityPull.enemy = this;
        AI.enemy = this;
        anim.enemy = this;
        status.enemy = this;

        player = GameObject.Find("Player");
        
        stat = new EnemyStat(data.movementSpeed, (int)data.health, data.delayAtk, (int)data.burstSize, data.burstDelay, data.coolDownAttk);
        inventory = new EnemyInventory(data.ammo, 4);

        agent.enabled = false;
    }

    RaycastHit hitInfo;
    private void Update() {
        isGrounded = Physics.CheckSphere(feet.position, .1f, groundMask);
        inAttackrange = Physics.CheckSphere(transform.position, 8f, playerMask);
        inChaseRange = Physics.CheckSphere(transform.position, 25f, playerMask);
        isSpotPlayer = Physics.SphereCast(transform.position, 5f, transform.forward, out hitInfo, 100f, playerMask);

        if(inChaseRange){
            isAgitated = true;
        }
        if(isGrounded){
            agent.enabled = true;
        }

        timeSinceLastAttack+=Time.deltaTime;
        if(timeSinceLastAttack > stat.attackCoolDown){
            hasAttack = false;
        }
    }
}

public abstract class EnemyBehaviour : MonoBehaviour{
    [HideInInspector]public Enemy enemy;
}
