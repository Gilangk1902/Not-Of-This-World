using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponUI : WeaponBehaviour
{
    public TMP_Text ammo;
    public TMP_Text mag;
    void Update(){
        mag.text = weapon.status.ammoInMag.ToString();
        ammo.text = weapon.status.ammo.ToString();
    }
}
