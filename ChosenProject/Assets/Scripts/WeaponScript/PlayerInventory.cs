using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : WeaponBehaviour
{
    public WeaponList list;

    public string obj_slot1;
    public string anim_slot1;
    public WeaponData data_slot1;

    public string obj_slot2;
    public string anim_slot2;
    public WeaponData data_slot2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ChangeWeapon(0,list.AR_name, list.AR_data);
            weapon.status.Switch();
        }
        else if(Input.GetKeyDown(KeyCode.L))
        {
            ChangeWeapon(0,list.pistol_name, list.pistol_data);
            weapon.status.Switch();
        }
    }

    public void ChangeWeapon(int slot,string name,WeaponData data)
    {
        if(slot == 0)
        {
            obj_slot1 = name;
            anim_slot1 = name;
            data_slot1 = data;
        }
        else if(slot == 1)
        {
            obj_slot2 = name;
            anim_slot2 = name;
            data_slot2 = data;
        }
    }
}
