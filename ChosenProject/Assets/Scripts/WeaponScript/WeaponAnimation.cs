using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class WeaponAnimation : WeaponBehaviour
{
    [SerializeField] public Animator anim;
    [SerializeField] Animator pistol;
    [SerializeField] Animator AR;
    bool oneTime = false;

    private void Start()
    {
        anim = pistol;
    }
    void Update()
    {
        //Debug.Log("shoot : " + weapon.shoot.isShooting + " " + "reload : " + weapon.status.isReloading);
        if (!weapon.status.isReloading)
        {
            oneTime = false;
        }

        if(weapon.shoot.isShooting && !weapon.status.isReloading)
        {
            anim.Play("Shoot");
            //Debug.Log("Shoot");
        }
        else if (!weapon.shoot.isShooting && weapon.status.isReloading)
        {
            if (!oneTime)
            {
                anim.Play("Reload");
                //Debug.Log("reload");
                oneTime = true;
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
