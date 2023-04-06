using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public static IEnumerator Shoot(Transform atkTransform ,float attackDelay, int burstSize, float burstDelay, int enemyAmmo, GameObject atkObj, bool isAttacking){
        yield return new WaitForSeconds(attackDelay);
        for(int i=0;i<burstSize;i++){
            yield return new WaitForSeconds(burstDelay);
            Instantiate(atkObj, atkTransform.position, atkTransform.rotation);
            enemyAmmo--;
        }
        isAttacking = false;
    }
}
