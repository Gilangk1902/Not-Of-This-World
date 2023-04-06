using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public static IEnumerator Shoot(Transform atkTransform ,float attackDelay, int burstSize, float burstDelay, EnemyInventory inventory, GameObject atkObj, bool isAttacking){
        yield return new WaitForSeconds(attackDelay);
        for(int i=0;i<burstSize;i++){
            yield return new WaitForSeconds(burstDelay);
            Instantiate(atkObj, atkTransform.position, atkTransform.rotation);
            inventory.ammo--;
        }
        isAttacking = false;
    }

    public static IEnumerator Reload(EnemyInventory inventory, int magsize, float reloadSpeed, Enemy enemy){
        yield return new WaitForSeconds(reloadSpeed);
        inventory.ammo = magsize;
        enemy.isReloading = false;
    }
}
