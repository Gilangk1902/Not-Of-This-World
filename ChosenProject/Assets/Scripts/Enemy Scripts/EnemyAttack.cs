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
    }
    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
    }

    public bool IsAtkAllowed()
    {
        if (enemy.spotPlayer && enemy.radar.inAttackRange && timeSinceLastAttack > enemy.data.coolDownAttk && atkAllowed)
        {
            return true;
        }
        return false;
    }
    public void Attack()
    {
        if(IsAtkAllowed())
        {
            StartCoroutine(WaitAndAttack());
            atkAllowed = false;
        }
    }
    IEnumerator WaitAndAttack()
    {
        for(int i=0;i<enemy.data.numOfAttackPerAtk;i++)
        {
            yield return new WaitForSeconds(enemy.data.delayBetweenAtk);

            Collider[] hit = Physics.OverlapSphere(transform.position, 2f, enemy.playerMask);
            for (int j = 0; j < hit.Length; j++)
            {
                if (hit[j].gameObject.layer == 6)
                {
                    hit[j].GetComponent<PlayerStatus>().TakeDamage(50);
                }
            }
        }   
    }
}
