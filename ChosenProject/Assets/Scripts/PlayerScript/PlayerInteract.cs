using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : PlayerBehaviour
{
    float handLength = 1f;
    public LayerMask interactMask;
    float timeSinceLastInteract;
    bool isInteractibles;
    [SerializeField] private Weapon weapon;

    private void Start()
    {
        timeSinceLastInteract = 1f;
    }
    void Update()
    {
        if(!weapon.status.isReloading && !weapon.shoot.isShooting && !weapon.status.isSwitching){
            Use();
            PickUp();
            Holding();
        }
        
        timeSinceLastInteract += Time.deltaTime;
    }
    RaycastHit hit;
    void Use()
    {
        if(Physics.Raycast(player.Camera.camera.transform.position, player.Camera.camera.transform.forward, out hit)){
            if(hit.transform.gameObject.layer == 8){
                player.UI.ShowIinteract();
                if (Input.GetKeyDown(KeyCode.E)){
                    Pick();
                }
            }
            else{
                player.UI.Stop_ShowInteract();
            }
        }
        else{
            player.UI.Stop_ShowInteract();
        }
    }

    [SerializeField] Transform hand;
    GameObject currentHoldingObject;
    bool isHolding = false;
    void PickUp(){
        if (Physics.Raycast(player.Camera.camera.transform.position, player.Camera.camera.transform.forward, out hit)){
            if (hit.transform.gameObject.layer == 8){
                if (Input.GetKeyDown(KeyCode.Z) && !isHolding && hit.transform.gameObject.GetComponent<PhysicsInteractibles>() != null)
                {
                    currentHoldingObject =  hit.transform.gameObject;
                    PhysicsInteractibles physics = currentHoldingObject.GetComponent<PhysicsInteractibles>();
                    physics.isHold = true;
                    physics.num_of_holds++;
                    isHolding = true;
                    timeSinceLastInteract = 0f;
                }
            }
        }
    }

    void Holding()
    {
        if (isHolding){
            currentHoldingObject.transform.position = hand.position;
            currentHoldingObject.transform.rotation = Quaternion.Euler(hand.transform.eulerAngles.x, hand.transform.eulerAngles.y, hand.transform.eulerAngles.z);
            if (Input.GetKeyDown(KeyCode.Z) && timeSinceLastInteract > .4f)
            {
                currentHoldingObject.GetComponent<PhysicsInteractibles>().isHold = false;
                isHolding= false;
            }
        }
    }


    void Pick(){
        if(hit.transform.gameObject.GetComponent<InteractablesBehaviour>() != null){
            InteractablesBehaviour behaviour = hit.transform.gameObject.GetComponent<InteractablesBehaviour>();
            behaviour.OnPickUp();
        }
    }
}
