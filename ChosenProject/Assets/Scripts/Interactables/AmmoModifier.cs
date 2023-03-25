using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoModifier : InteractablesBehaviour
{
    private Weapon weapon;
    private GameObject player;
    [SerializeField] private Interactables interact;
    private void Awake()
    {
        player = GameObject.Find("Player");
        Transform grandChildren = player.transform.Find("EyePosition/Main Camera/InventoryChace/WeaponHolder");
        weapon = grandChildren.GetComponent<Weapon>();
    }
    public override void OnPickUp()
    {
        weapon.data.ammoInInventory += (int)interact.data.value;
    }
}
