using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : WeaponBehaviour
{
    public Transform muzzleBarrel;
    public bool enable;
    public LayerMask EnemyMask;
    public float timeSinceLastShot;
    [HideInInspector] public float fireRate;
    void Start() {
        timeSinceLastShot = weapon.data.fireRate;    
        fireRate = weapon.data.fireRate;
    }
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }

    public void Shoot(){
        if(weapon.data.ammoInMag > 0 && !weapon.status.isReloading){
            if(timeSinceLastShot > fireRate){
                RaycastHit hit;
                if(Physics.Raycast(muzzleBarrel.position, muzzleBarrel.forward, out hit)){
                    if(hit.transform.gameObject.layer == 7){
                        EnemyStatus hitStatus = hit.collider.gameObject.GetComponent<EnemyStatus>();
                        hitStatus.TakeDamage(weapon.data.damage);
                        Debug.Log("Hit");
                    }
                }
                weapon.data.ammoInMag--;
                timeSinceLastShot = 0f;
            }
        }
    }

    public void Secondary()
    {
        if(weapon.data.name == "AR")
        {
            //Grenade Launncher
        }
        else if(weapon.data.name == "Pistol")
        {
            //AIMBOT
        }
    }
}
