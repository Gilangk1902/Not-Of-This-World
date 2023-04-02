using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : InteractablesBehaviour
{
    [SerializeField] private Interactables interact;
    [SerializeField] GameObject doorObject;
    public bool isClosed;

    private void Start()
    {
        isClosed = true; ;
    }
    private void Update()
    {
            
    }
    public override void OnPickUp()
    {
        rotating = true;
        if (isClosed)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    private float timeCount = 0f;
    public bool rotating = false;
    private void OpenDoor()
    {
        transform.Rotate(0,90,0, Space.Self);
        isClosed = false;
    }

    private void CloseDoor()
    {
        transform.Rotate(0,-90,0, Space.Self);
        isClosed = true;
    }
}
    
