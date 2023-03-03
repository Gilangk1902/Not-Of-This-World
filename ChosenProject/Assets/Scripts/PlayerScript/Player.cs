using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isGrounded;
    public Transform feet;
    public Transform eye;
    public LayerMask groundMask;
    public LayerMask interactablesMask;
    public bool pickUpRange;

    
    public Movement movement;
    public PlayerStatus status;
    public PlayerCamera Camera;
    public PlayerUI UI;
    public PlayerData data;
    public PlayerInteract interact;
    void Update() {
        isGrounded = Physics.CheckSphere(feet.position, .1f, groundMask);
        pickUpRange = Physics.CheckSphere(transform.position, 3f, interactablesMask);
    }

    void Awake() {
        movement.player = this;
        status.player = this;
        Camera.player = this;    
        UI.player = this;
        interact.player = this;
    }
}

public abstract class PlayerBehaviour : MonoBehaviour
{
    [HideInInspector]public Player player;
}
