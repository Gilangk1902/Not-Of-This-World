using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapon", menuName ="Weapon/Data")]
public class WeaponData : ScriptableObject
{
    public bool available;
    public string name;

    public float damage;
    public float maxDistance;
    
    public int maxAmmo;
    public int ammoInInventory;
    public int magSize;
    public int ammoInMag;
    public float fireRate;
    public float reloadTime;
    public float bulletSpread;
    
}
