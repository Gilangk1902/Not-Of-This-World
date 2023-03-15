using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoModifier : InteractablesBehaviour
{
    private Weapon weapon;
    private void Awake()
    {
        weapon = GameObject.Find("Player").GetComponentInChildren<Weapon>();
    }
    public override void OnPickUp()
    {
        weapon.data.ammoInInventory += (int)interactables.data.value;
    }
}
