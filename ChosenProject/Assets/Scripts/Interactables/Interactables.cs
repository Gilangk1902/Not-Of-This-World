using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public Player player;
    public InteractablesData data;

    public void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
}

public abstract class InteractablesBehaviour : MonoBehaviour
{
    [HideInInspector] public Interactables interactables;
    public abstract void OnPickUp();
}
