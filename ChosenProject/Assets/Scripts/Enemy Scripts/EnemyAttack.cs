using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : EnemyBehaviour
{
    float timeSinceLastAttack;
    public Transform attackLoc;
    bool atkAllowed;

    private void Start()
    {
        timeSinceLastAttack = enemy.data.coolDownAttk;
        atkAllowed = true;
    }
    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        Attack();
        AtkReset();
        Debug.Log(timeSinceLastAttack);
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
            Debug.Log("atk is allowrd");
            StartCoroutine(WaitAndAttack());
        }
    }

    bool hasHit = false;
    IEnumerator WaitAndAttack()
    {
        for(int i=0;i<enemy.data.numOfAttackPerAtk;i++)
        {
            hasHit = false;
            yield return new WaitForSeconds(enemy.data.delayBetweenAtk);
            Debug.Log("sex");

            Collider[] hit = Physics.OverlapSphere(transform.position, 2f, enemy.playerMask);
            for (int j = 0; j < hit.Length; j++)
            {
                if (hit[j].gameObject.layer == 6 && !hasHit)
                {
                    hit[j].GetComponent<PlayerStatus>().TakeDamage(enemy.data.damage);
                    hasHit = true;
                }
            }
        }   
        atkAllowed = false;
        timeSinceLastAttack = 0;
    }

    void AtkReset(){
        if(timeSinceLastAttack > enemy.data.coolDownAttk){
            atkAllowed = true;
            hasHit = false;
        }
    }
}
