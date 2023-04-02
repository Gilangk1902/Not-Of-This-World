using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{
    [Header("Pistol")]
    public string pistol_name;
    public WeaponData pistol_data;
    public GameObject pistol_Anim;
    public GameObject pistol_Object;

    [Header("AssaultRifle")]
    public string AR_name;
    public WeaponData AR_data;
    public GameObject AR_Anim;
    public GameObject AR_Object;

    [Header("Holster")]
    public string holster_name;
    public WeaponData holster_data;
    public GameObject holster_Anim;
    public GameObject holster_Object;
}
