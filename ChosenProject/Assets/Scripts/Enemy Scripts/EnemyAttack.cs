using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : EnemyBehaviour
{
    float timeSinceLastAttack;
    public Transform attackLoc;
    bool atkAllowed;
    public bool isAttacking;

    private void Start()
    {
        timeSinceLastAttack = enemy.data.coolDownAttk;
        atkAllowed = true;
        isAttacking = false;
    }
    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        Attack();
        AtkReset();
    }

    public bool IsAtkAllowed()
    {
        if (enemy.spotPlayer && enemy.radar.inAttackRange && timeSinceLastAttack > enemy.data.coolDownAttk && atkAllowed)
        {
            return true;
        }
        else{
            return false;
        }
    }
    public void Attack()
    {
        if(enemy.radar.inAttackRange && atkAllowed)
        {
            if(enemy.data.type == "Melee"){
                StartCoroutine(Melee_WaitAndAttack());
            }
            else if(enemy.data.type == "Ranged"){
                StartCoroutine(Ranged_WaitAndAttack());
            }
        }
    }

    bool hasHit_melee;
    IEnumerator Melee_WaitAndAttack()
    {
        isAttacking = true;
        
        hasHit_melee = false;
        yield return new WaitForSeconds(enemy.data.delayAtk);

        Collider[] hit = Physics.OverlapSphere(attackLoc.position, 2f, enemy.playerMask);
        for (int j = 0; j < hit.Length; j++)
        {
            if (hit[j].gameObject.layer == 6 && !hasHit_melee)
            {
                hit[j].GetComponent<PlayerStatus>().TakeDamage(enemy.data.damage);
                hasHit_melee = true;
            }
        }
        atkAllowed = false;
        isAttacking = false;
        timeSinceLastAttack = 0;
    }

    bool hasInstantiate = false;
    IEnumerator Ranged_WaitAndAttack(){
        isAttacking = true;
        yield return new WaitForSeconds(enemy.data.delayAtk);
        if(!hasInstantiate){
            Instantiate(enemy.data.bullet, attackLoc.position, attackLoc.rotation); 
            hasInstantiate = true;
        }

        atkAllowed = false;
        isAttacking = false;
        timeSinceLastAttack = 0;
        
    }

    void AtkReset(){
        if(timeSinceLastAttack > enemy.data.coolDownAttk){
            atkAllowed = true;
            hasInstantiate = false;
        }
    }
}
