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

        if (weapon.data.available && !weapon.status.isSwitching && !weapon.status.isReloading)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Shoot();
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Secondary();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                weapon.status.Reload();
            }
        }

        if (isLock)
        {
            AimLock();
        }
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
        if (weapon.data.name == "AR")
        {
            //Grenade Launncher
        }
        else if (weapon.data.name == "Pistol")
        {
            if (isLock)
            {
                AimLockRelease();
            }
            else if (!isLock)
            {
                AimLockTrigger();
            }
        }
    }

    public float aimRadius;
    public float aimDistance;
    public bool isLock;
    public PlayerCamera camera;
    GameObject target;
    public void AimLockTrigger()
    {
        //get enemy object position, with raycast, store in array
        //rotate camera to...
        RaycastHit hit;

        //TODO  change to sphereCastAll
        if(Physics.SphereCast(muzzleBarrel.position, aimRadius, muzzleBarrel.forward, out hit, aimDistance))
        {
            if(hit.transform.gameObject.layer == 7)
            {
                if(hit.transform.Find("Target") != null){
                    target = hit.transform.Find("Target").gameObject;
                }
                camera.enable = false;
                isLock = true;
                Debug.Log("lock");
            }
        }
    }

    public void AimLock()
    {
        camera.CameraLockedOnTargetHorizontal(target.transform.position);
        camera.CameraLockedOnTargetVertical(target.transform.position);
    }

    public void AimLockRelease()
    {
        camera.enable = true;
        isLock = false;
        Debug.Log("Release");
    }
}
