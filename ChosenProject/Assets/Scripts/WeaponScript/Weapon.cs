using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData data;
    public WeaponData pistol;
    public WeaponData AssaultRifle;
    public WeaponShooting shoot;
    public WeaponStatus status;
    public WeaponUI ui;
    public WeaponAnimation anim;
    public PlayerInventory inventory;

    void Awake(){
        shoot.weapon = this;
        status.weapon = this;
        ui.weapon = this;
        anim.weapon = this;
        inventory.weapon = this;
        
        pistol.ammoInInventory = pistol.maxAmmo;
        pistol.ammoInMag = pistol.magSize;
        AssaultRifle.ammoInInventory = AssaultRifle.maxAmmo;
        AssaultRifle.ammoInMag = AssaultRifle.magSize;
    }

    void Update(){
        
    }
}

public abstract class WeaponBehaviour : MonoBehaviour
{
    [HideInInspector]public Weapon weapon;
}
