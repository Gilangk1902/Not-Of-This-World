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
    public int magSize;
    public float fireRate;
    public float reloadTime;
    public bool isReloading;
    public float bulletSpread;
    
}
