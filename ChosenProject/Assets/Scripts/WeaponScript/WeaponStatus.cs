using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatus : WeaponBehaviour
{

    public int ammoInMag;
    public int ammo;
    public bool isReloading;
    public bool playReloadAnim;
    public int currentWeapon;
    public int prevWeapon;

    public bool isSwitching;
    public float timeSinceLastSwitch;



    void Start() {
        weapon.data.ammoInInventory = weapon.data.maxAmmo;
        weapon.data.ammoInMag = weapon.data.magSize;
    }
    void Update(){
        Reload();
        SwitchingWeapon();

        timeSinceLastSwitch += Time.deltaTime;
        if(timeSinceLastSwitch > weapon.data.swithcSpeed)
        {
            isSwitching= false;
        }
    }

    public void Reload(){
        if(Input.GetKeyDown(KeyCode.R)){
            if(weapon.data.ammoInMag < weapon.data.magSize && !isSwitching && !weapon.shoot.isShooting){
                isReloading = true;
                Invoke("FillAmmo", weapon.data.reloadTime);
            }
        }
    }
    public void FillAmmo(){
        weapon.data.ammoInInventory -= (weapon.data.magSize-weapon.data.ammoInMag);
        weapon.data.ammoInMag = weapon.data.magSize;
        isReloading = false;
    }
    private KeyCode[] keyCodes = {
        KeyCode.Alpha1
    };
    public void SwitchingWeapon(){
        for(int i=0;i<keyCodes.Length;i++){
            if(Input.GetKeyDown(keyCodes[i])){
                currentWeapon = i;
                if(currentWeapon!=prevWeapon && !isSwitching){
                    prevWeapon = currentWeapon;
                    Switch();
                }
            }
        }
    }

    public void Switch()
    {
        if (currentWeapon == 0 && weapon.inventory.obj_slot1 != null)
        {
            weapon.data = weapon.inventory.data_slot1;
            weapon.anim.ChangeTo(weapon.inventory.anim_slot1);
            ChangeModel(weapon.inventory.obj_slot1);
            timeSinceLastSwitch = 0;
            isSwitching = true;

        }
    }


    private void ChangeModel(string name)
    {
        if(name == "Pistol")
        {
            weapon.inventory.list.pistol_Anim.SetActive(true);
            weapon.inventory.list.AR_Anim.SetActive(false);
            weapon.inventory.list.holster_Anim.SetActive(false);
        }
        else if(name == "AR")
        {
            weapon.inventory.list.AR_Anim.SetActive(true);
            weapon.inventory.list.pistol_Anim.SetActive(false);
            weapon.inventory.list.holster_Anim.SetActive(false);
        }
        else if(name == "Holster"){
            weapon.inventory.list.holster_Anim.SetActive(true);
            weapon.inventory.list.AR_Anim.SetActive(false);
            weapon.inventory.list.pistol_Anim.SetActive(false);
        }
    }
}
