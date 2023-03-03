using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModifier : InteractablesBehaviour
{
    public override void OnPickUp()
    {
        interactables.player.data.health += ((int)interactables.data.value);
        Destroy(gameObject);
        Debug.Log("picked up");
    }
}
