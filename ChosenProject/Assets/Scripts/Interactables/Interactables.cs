using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public Player player;
    public HealthModifier health;
    public InteractablesData data;

    public void Awake()
    {
        health.interactables = this;
    }
}

public abstract class InteractablesBehaviour : MonoBehaviour
{
    [HideInInspector] public Interactables interactables;
    public abstract void OnPickUp();
}
