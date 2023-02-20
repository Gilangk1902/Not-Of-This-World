using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatus : WeaponBehaviour
{
    public int ammoInMag;
    public int ammo;

    void Start() {
        ammoInMag = weapon.data.magSize;
        ammo = weapon.data.maxAmmo;    
    }
    void Update(){

    }

    public void Reload(){
        ammo = ammo - (weapon.data.magSize - ammoInMag);
        ammoInMag = weapon.data.magSize;
    }
}
