using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class WeaponAnimation : WeaponBehaviour
{
    [SerializeField] public Animator anim;
    [SerializeField] Animator pistol;
    [SerializeField] Animator AR;
    bool oneTimeReload = false;
    bool oneTimeSwitch = false;

    private void Start()
    {
        anim = pistol;
    }
    void Update()
    {
        if (!weapon.status.isReloading)
        {
            oneTimeReload = false;
        }
        if(!weapon.status.isSwitching){
            oneTimeSwitch = false;
        }

        if(weapon.status.isSwitching){
            if(!oneTimeSwitch){
                anim.Play("Switch");
                oneTimeSwitch = true;
            }
        }
        else if(weapon.shoot.isShooting && !weapon.status.isReloading && !weapon.status.isSwitching)
        {
            anim.Play("Shoot");
        }
        else if (!weapon.shoot.isShooting && weapon.status.isReloading && !weapon.status.isSwitching)
        {
            if (!oneTimeReload)
            {
                anim.Play("Reload");
                oneTimeReload = true;
            }
        }
        else if(!weapon.shoot.isShooting && !weapon.status.isReloading)
        {
            //anim.Play("Idle");
        }
    }
    public void ChangeTo(string name)
    {
        if (name == "Pistol")
        {
            anim = pistol;
        }
        else if(name == "AR")
        {
            anim = AR;
        }
    }
}
