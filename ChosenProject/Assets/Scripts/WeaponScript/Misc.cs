using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misc : MonoBehaviour
{
    public Player player;
    public Weapon weapon;
    public MiscItemData misc;
    public int healQuantity;

    private void Start()
    {
        healQuantity = misc.healingQuantity;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) {
            if (healQuantity > 0)
            {
                player.status.HealPlayer(misc.healingStrength);
                healQuantity--;
            }
        }
    }
}
