using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : WeaponBehaviour
{
    public Transform muzzleBarrel;
    public bool enable;
    public LayerMask EnemyMask;
    public float timeSinceLastShot;
    public bool isShooting;
    [HideInInspector] public float fireRate;
    [SerializeField] GameObject hitMarker;
    void Start() {
        timeSinceLastShot = weapon.data.fireRate;    
        fireRate = weapon.data.fireRate;
    }
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (weapon.data.available && !weapon.status.isSwitching && !weapon.status.isReloading)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
            }
            if (Input.GetButtonDown("Fire2"))
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
            if(timeSinceLastShot >= weapon.data.fireRate){
                RaycastHit hit;
                if(Physics.Raycast(muzzleBarrel.position, muzzleBarrel.forward, out hit)){
                    if(hit.transform.gameObject.layer == 7){
                        EnemyStatus hitStatus = hit.collider.gameObject.GetComponent<EnemyStatus>();
                        hitStatus.TakeDamage(weapon.data.damage);
                        hitMarker.SetActive(true);
                    }
                    if(hit.transform.gameObject.layer == 8){
                        if(hit.collider.gameObject.GetComponent<Destructables>()!=null){
                            Destructables hitStatus = hit.collider.gameObject.GetComponent<Destructables>();
                            hitStatus.TakeDamage(weapon.data.damage);
                            hitMarker.SetActive(true);
                        }
                    }
                }
                
                weapon.data.ammoInMag--;
                timeSinceLastShot = 0f;
                isShooting = true;
            }
            else
            {
                isShooting = false;
            }
        }
        else
        {
            isShooting = false;
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
        
    }
}
