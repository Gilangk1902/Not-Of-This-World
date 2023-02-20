using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData data;
    public WeaponShooting shoot;
    public WeaponStatus status;
    public WeaponUI ui;

    void Awake(){
        shoot.weapon = this;
        status.weapon = this;
        ui.weapon = this;
    }

    void Update(){
        if(data.available){
            if(Input.GetKey(KeyCode.Mouse0)){
                shoot.Shoot();
            }
            if(Input.GetKeyDown(KeyCode.R)){
                status.Reload();
            }
        }
    }
}

public abstract class WeaponBehaviour : MonoBehaviour
{
    [HideInInspector]public Weapon weapon;
}
