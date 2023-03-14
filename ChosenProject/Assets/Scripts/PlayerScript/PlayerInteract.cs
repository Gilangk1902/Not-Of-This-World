using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : PlayerBehaviour
{
    float handLength = 1f;
    public LayerMask interactMask;
    float timeSinceLastInteract;
    bool isInteractibles;

    private void Start()
    {
        timeSinceLastInteract = 1f;
    }
    void Update()
    {
        Use();
        PickUp();
        Holding();
        timeSinceLastInteract += Time.deltaTime;
    }
    RaycastHit hit;
    void Use()
    {
        if(Physics.Raycast(player.Camera.camera.transform.position, player.Camera.camera.transform.forward, out hit))
        {
            if(hit.transform.gameObject.layer == 8)
            {
                player.UI.ShowIinteract();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetVar();
                }
            }
            else
            {
                player.UI.Stop_ShowInteract();
            }
        }
        else
        {
            player.UI.Stop_ShowInteract();
        }
    }

    [SerializeField] Transform hand;
    GameObject currentHoldingObject;
    bool isHolding = false;
    void PickUp()
    {
        if (Physics.Raycast(player.Camera.camera.transform.position, player.Camera.camera.transform.forward, out hit))
        {
            if (hit.transform.gameObject.layer == 8)
            {
                if (Input.GetKeyDown(KeyCode.Z) && !isHolding && hit.transform.gameObject.GetComponent<PhysicsInteractibles>() != null)
                {
                    currentHoldingObject =  hit.transform.gameObject;
                    currentHoldingObject.GetComponent<PhysicsInteractibles>().isHold = true;
                    isHolding = true;
                    timeSinceLastInteract = 0f;
                }
            }
        }
    }

    void Holding()
    {
        if (isHolding)
        {
            currentHoldingObject.transform.position = hand.position;
            currentHoldingObject.transform.rotation = Quaternion.Euler(hand.transform.eulerAngles.x, hand.transform.eulerAngles.y, hand.transform.eulerAngles.z);
            if (Input.GetKeyDown(KeyCode.Z) && timeSinceLastInteract > .4f)
            {
                currentHoldingObject.GetComponent<PhysicsInteractibles>().isHold = false;
                isHolding= false;
            }
        }
    }

    void GetVar()
    {
        if(hit.transform.gameObject.GetComponent<Interactables>().data.type == "health")
        {
            hit.transform.gameObject.GetComponent<HealthModifier>().OnPickUp();
        }
        else if(hit.transform.gameObject.GetComponent<Interactables>().data.type == "door")
        {
            hit.transform.gameObject.GetComponent<Door>().OnPickUp();
        }
        else
        {
            return;
        }
    }
}
