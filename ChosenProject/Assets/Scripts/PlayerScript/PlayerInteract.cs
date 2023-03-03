using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : PlayerBehaviour
{
    float handLength = 1f;
    public LayerMask interactMask;

    void Update()
    {
        Pick();
    }
    RaycastHit hit;
    void Pick()
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

    void GetVar()
    {
        if(hit.transform.gameObject.GetComponent<Interactables>().data.type == "health")
        {
            hit.transform.gameObject.GetComponent<Interactables>().health.OnPickUp();
        }
        else
        {
            return;
        }
    }
}
