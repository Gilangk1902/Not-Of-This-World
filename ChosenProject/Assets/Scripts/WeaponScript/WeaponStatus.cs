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
    public GameObject pistol;
    public GameObject AR;

    void Start() {
        weapon.data.ammoInInventory = weapon.data.maxAmmo;
        weapon.data.ammoInMag = weapon.data.magSize;
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
        weapon.data.ammoInInventory -= (weapon.data.magSize-weapon.data.ammoInMag);
        weapon.data.ammoInMag = weapon.data.magSize;
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
            pistol.SetActive(true);
            AR.SetActive(false);
        }
        else if(currentWeapon==1){
            weapon.data = weapon.AssaultRifle;
            pistol.SetActive(false);
            AR.SetActive(true);
        }
    }
}
