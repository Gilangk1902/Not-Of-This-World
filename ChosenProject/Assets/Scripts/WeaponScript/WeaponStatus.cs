using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatus : WeaponBehaviour
{

    public int ammoInMag;
    public int ammo;
    public bool isReloading;
    public int currentWeapon;
    public int prevWeapon;

    void Start() {
        ammoInMag = weapon.data.magSize;
        ammo = weapon.data.maxAmmo;    
    }
    void Update(){
        Reload();
        SwitchingWeapon();
    }

    public void Reload(){
        if(Input.GetKeyDown(KeyCode.R)){
            isReloading = true;
            Invoke("FillAmmo", weapon.data.reloadTime);
        }
    }
    public void FillAmmo(){
        ammo = ammo - (weapon.data.magSize - ammoInMag);
        ammoInMag = weapon.data.magSize;
        isReloading = false;
    }
    private KeyCode[] keyCodes = {
        KeyCode.Alpha1, 
        KeyCode.Alpha2,
        KeyCode.Alpha3
    };
    public void SwitchingWeapon(){
        for(int i=0;i<keyCodes.Length;i++){
            if(Input.GetKeyDown(keyCodes[i])){
                currentWeapon = i;
                if(currentWeapon!=prevWeapon){
                    prevWeapon = currentWeapon;
                    Switch();
                }
            }
        }
    }

    public void Switch(){
        if(currentWeapon==0){  
            weapon.data = weapon.pistol;
            ammoInMag = weapon.data.magSize;
            ammo = weapon.data.maxAmmo;
            weapon.shoot.fireRate = weapon.data.fireRate;
            weapon.shoot.timeSinceLastShot = weapon.shoot.fireRate;
        }
        else if(currentWeapon==1){
            weapon.data = weapon.AssaultRifle;
            ammoInMag = weapon.data.magSize;
            ammo = weapon.data.maxAmmo;
            weapon.shoot.fireRate = weapon.data.fireRate;
            weapon.shoot.timeSinceLastShot = weapon.shoot.fireRate;
        }
    }
}
