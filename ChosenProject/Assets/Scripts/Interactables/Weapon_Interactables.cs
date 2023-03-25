using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Interactables : InteractablesBehaviour
{
    [SerializeField] private string names;
    private int index;
    [SerializeField] private WeaponData data;
    private PlayerInventory inventory;
    private WeaponStatus status;
    private GameObject player;
    private void Awake() {
        player = GameObject.Find("Player");
        Transform grandChildren = player.transform.Find("EyePosition/Main Camera/InventoryChace/WeaponHolder");
        inventory = grandChildren.GetComponent<PlayerInventory>();
        status = grandChildren.GetComponent<WeaponStatus>();
    }
    public override void OnPickUp()
    {
        index = status.currentWeapon;
        if(inventory.data_slot1.name != names){
            inventory.ChangeWeapon(index, names, data);
            Destroy(gameObject);
        }
    }
}
