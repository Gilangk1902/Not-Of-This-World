using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : EnemyBehaviour
{
    private Vector3 targetMoveLocation;
    private float timeSinceLastAttack = 0f;
    private void Update() {
        Debug.Log(targetMoveLocation);

        if(enemy.isAgitated && !enemy.isMoving)
        {
            if(!enemy.inAttackrange){
                EnemyRotation.Rotate(enemy.player.transform.position, enemy.transform);
                EnemyMovement.StandStill(enemy.agent, enemy.transform);
                if(enemy.isSpotPlayer && !enemy.isAttacking){
                    targetMoveLocation = enemy.player.transform.position;
                    enemy.isMoving = true;
                }
            }
            else if(enemy.inAttackrange){
                EnemyRotation.Rotate(enemy.player.transform.position, enemy.transform);
                EnemyMovement.StandStill(enemy.agent, enemy.transform);

                //Attack
                if(!enemy.hasAttack && enemy.inventory.ammo > 0){
                    StartCoroutine(EnemyAttack.Shoot(enemy.atkTransform, enemy.stat.attackDelay, 
                                                    enemy.stat.burstSize, enemy.stat.burstDelay, enemy.inventory, 
                                                    enemy.atkObj, enemy.isAttacking));
                    enemy.hasAttack = true;
                    enemy.timeSinceLastAttack = 0f;
                }
                else if(enemy.inventory.ammo <=0 && !enemy.isReloading){
                    enemy.isReloading = true;
                    StartCoroutine(EnemyAttack.Reload(enemy.inventory, enemy.inventory.magsize, enemy.stat.attackCoolDown, enemy));
                }
            }
        }
        else if(enemy.isAgitated && enemy.isMoving){
            targetMoveLocation.y =  transform.position.y;
            EnemyMovement.MoveTo(enemy.agent, targetMoveLocation, enemy.stat.speed);
            if(enemy.inAttackrange || Vector3.Distance(enemy.transform.position, targetMoveLocation) < .5f){
                enemy.isMoving = false;
            }
        }
    }
    
    
}
