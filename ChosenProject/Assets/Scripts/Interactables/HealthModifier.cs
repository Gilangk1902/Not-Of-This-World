using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModifier : InteractablesBehaviour
{
    [SerializeField] private Interactables interact;
    public override void OnPickUp()
    {
        interact.player.data.health += ((int)interact.data.value);

        Destroy(gameObject);
    }
}
