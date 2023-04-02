using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyAttack : EnemyBehaviour
{
    float timeSinceLastAttack;
    float timeSinceLastReload;
    public Transform attackLoc;
    public bool isAttacking;
    public bool isReloading;
    private bool oneTime_shoot;
    private bool oneTime_reload;

    private void Start()
    {
        timeSinceLastAttack = enemy.data.coolDownAttk;
        timeSinceLastReload = 1f;
        isAttacking = false;
        
        oneTime_shoot = false;
        oneTime_reload = false;
    }
    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        timeSinceLastReload += Time.deltaTime;
        if (enemy.radar.inAttackRange && !oneTime_shoot && !enemy.movement.isMoving)
        {
            isAttacking = true;
            if(enemy.data.type == "Melee")
            {
                StartCoroutine(Melee_Atk());
            }
            else if(enemy.data.type == "Ranged" && enemy.data.ammo>0)
            {
                StartCoroutine(Ranged_Atk());
            }
            oneTime_shoot = true;
            timeSinceLastAttack = 0;
        }

        if(enemy.data.type == "Ranged" && enemy.data.ammo<=0 &&!oneTime_reload){
            StartCoroutine(Reload());
            oneTime_reload = true;
        }
        ResetAttack();
        ResetReload();
    }

    IEnumerator Melee_Atk()
    {
        yield return new WaitForSeconds(enemy.data.delayAtk);
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(enemy.data.burstDelay);
        }
        isAttacking = false;
    }

    IEnumerator Ranged_Atk()
    {
        yield return new WaitForSeconds(enemy.data.delayAtk);
        for (int i = 0; i < enemy.data.burstSize; i++)
        {
            yield return new WaitForSeconds(enemy.data.burstDelay);
            Instantiate(enemy.data.bullet, attackLoc.transform.position, attackLoc.transform.rotation);
            enemy.data.ammo--;
        }
        isAttacking = false;
    }

    IEnumerator Reload(){
        isReloading = true;
        yield return new WaitForSeconds(enemy.data.reloadTime);
        enemy.data.ammo = enemy.data.magSize;
        timeSinceLastReload = 0f;
        isReloading = false;
    }

    void ResetAttack()
    {
        if (timeSinceLastAttack > enemy.data.coolDownAttk)
        {
            oneTime_shoot = false;
        }
    }

    void ResetReload(){
        if(timeSinceLastReload > 1f){
            oneTime_reload = false;
        }
    }

}
