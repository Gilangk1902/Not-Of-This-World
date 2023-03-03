using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//u were trying to only startcoroutine onetime only, using bool oneTime
public class EnemyAttack : EnemyBehaviour
{
    float timeSinceLastAttack;
    public Transform attackLoc;
    public bool isAttacking;
    public int ammo;
    private bool oneTime;

    private void Start()
    {
        timeSinceLastAttack = enemy.data.coolDownAttk;
        isAttacking = false;
        ammo = 5;
        oneTime = false;
    }
    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        if (enemy.radar.inAttackRange && !oneTime && !enemy.movement.isMoving)
        {
            isAttacking = true;
            if(enemy.data.type == "Melee")
            {
                StartCoroutine(Melee_Atk());
            }
            else if(enemy.data.type == "Ranged")
            {
                StartCoroutine(Ranged_Atk());
            }
            oneTime = true;
            timeSinceLastAttack = 0;
        }
        ResetAttack();
    }

    IEnumerator Melee_Atk()
    {
        yield return new WaitForSeconds(enemy.data.delayAtk);
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(enemy.data.burstDelay);
            Debug.Log("Atk");
        }
        isAttacking = false;
    }

    IEnumerator Ranged_Atk()
    {
        yield return new WaitForSeconds(enemy.data.delayAtk);
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(enemy.data.burstDelay);
            Debug.Log("Atk");
            Instantiate(enemy.data.bullet, attackLoc.transform.position, attackLoc.transform.rotation);
        }
        isAttacking = false;
    }

    void ResetAttack()
    {
        if (timeSinceLastAttack > enemy.data.coolDownAttk)
        {
            oneTime = false;
        }
    }

}
