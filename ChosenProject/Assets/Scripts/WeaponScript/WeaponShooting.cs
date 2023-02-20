using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : WeaponBehaviour
{
    public Transform muzzleBarrel;
    public bool enable;
    public LayerMask EnemyMask;
    float timeSinceLastShot;
    void Start() {
        timeSinceLastShot = weapon.data.fireRate;    
    }
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    public void Shoot(){
        if(weapon.status.ammoInMag > 0){
            if(timeSinceLastShot > weapon.data.fireRate){
                RaycastHit hit;
                if(Physics.Raycast(muzzleBarrel.position, muzzleBarrel.forward, out hit)){
                    if(hit.transform.gameObject.layer == 7){
                        EnemyStatus hitStatus = hit.collider.gameObject.GetComponent<EnemyStatus>();
                        hitStatus.TakeDamage(weapon.data.damage);
                        Debug.Log("Hit");
                    }
                }
                weapon.status.ammoInMag--;
                timeSinceLastShot = 0f;
            }
        }
    }
}
