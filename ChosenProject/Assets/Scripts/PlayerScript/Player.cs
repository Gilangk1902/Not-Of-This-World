using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isGrounded;
    public Transform feet;
    public Transform eye;
    public LayerMask groundMask;

    
    public Movement movement;
    public PlayerStatus status;
    public PlayerCamera Camera;
    public PlayerUI UI;
    void Update() {
        isGrounded = Physics.CheckSphere(feet.position, .1f, groundMask);
    }

    void Awake() {
        movement.player = this;
        status.player = this;
        Camera.player = this;    
        UI.player = this;
    }
}

public abstract class PlayerBehaviour : MonoBehaviour
{
    [HideInInspector]public Player player;
}
