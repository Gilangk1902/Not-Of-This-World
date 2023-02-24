using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponUI : WeaponBehaviour
{
    public TMP_Text ammo;
    public TMP_Text mag;
    void Update(){
        mag.text = weapon.data.ammoInMag.ToString();
        ammo.text = weapon.data.ammoInInventory.ToString();
    }
}
