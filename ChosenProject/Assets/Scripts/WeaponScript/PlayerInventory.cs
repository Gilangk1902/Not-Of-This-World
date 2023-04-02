using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : WeaponBehaviour
{
    public WeaponList list;
    public InventorySlot slot1;

    private void Start() {
        slot1 = new InventorySlot("Pistol", list.pistol_data);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)){
            DropWeapon(weapon.status.currentWeapon);
        }

        Debug.Log("Slot 1 Name: " + slot1.GetName());
    }

    public void ChangeWeapon(int slot,string name,WeaponData data)
    {   
        if(slot1.GetName() == "Pistol"){
            Instantiate(list.pistol_Object, transform.position, transform.rotation);
        }
        else if(slot1.GetName() == "AR"){
            Instantiate(list.AR_Object, transform.position, transform.rotation);
        }
        Slot_Change(slot, name, data);
        weapon.status.Switch();
        
    }

    public void DropWeapon(int slot){
        if(slot ==  0){
            if(slot1.GetName() == "Pistol"){
                Instantiate(list.pistol_Object, transform.position, transform.rotation);
            }
            else if(slot1.GetName() == "AR"){
                Instantiate(list.AR_Object, transform.position, transform.rotation);
            }
            Slot_Change(slot, "Holster", list.holster_data);
            weapon.status.Switch();
        }
    }

    private void Slot_Change(int slot, string name, WeaponData data){
        if(slot == 0){
            slot1.SetName(name);
            slot1.SetData(data);
        }
    }
}
