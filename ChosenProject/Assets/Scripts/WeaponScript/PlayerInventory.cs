using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : WeaponBehaviour
{
    public WeaponList list;

    public string obj_slot1;
    public string anim_slot1;
    public WeaponData data_slot1;

    

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)){
            DropWeapon(0);
        }
    }

    public void ChangeWeapon(int slot,string name,WeaponData data)
    {
        if(slot == 0)
        {
            if(obj_slot1 == "Pistol"){
                Instantiate(list.pistol_Object, transform.position, transform.rotation);
            }
            else if(obj_slot1 == "AR"){
                Instantiate(list.AR_Object, transform.position, transform.rotation);
            }
            obj_slot1 = name;
            anim_slot1 = name;
            data_slot1 = data;
            weapon.status.Switch();
        }
        
    }

    public void DropWeapon(int slot){
        if(slot ==  0){
            if(obj_slot1 == "Pistol"){
                Instantiate(list.pistol_Object, transform.position, transform.rotation);
            }
            else if(obj_slot1 == "AR"){
                Instantiate(list.AR_Object, transform.position, transform.rotation);
            }
            obj_slot1 = "Holster";
            anim_slot1 = "Holster";
            data_slot1  = list.holster_data;
            weapon.status.Switch();
        }
    }

    public void Slot_Change(string name, WeaponData data){

    }
}
