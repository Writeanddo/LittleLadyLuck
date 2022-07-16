using UnityEngine;

public class PlayerTransform : MonoBehaviour {

    public Transform groundPoint;
    public Vector2 diceSize;
    [SerializeField][Tooltip("land accel, air accel, jump height, max speed")] public Vector4 movementMultipliers;


    private CapsuleCollider2D playerCollider;
    private PlayerMovement move;
    private PlayerJump jump;
    private Animator animator;
    private bool transformed = false;
    private Vector2 offset;

    void Awake() {
        move = GetComponent<PlayerMovement>();
        jump = GetComponent<PlayerJump>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // void OnE() {
    //     ToggleTransform();
    // }

    public bool IsTransformed() { return transformed; }
    
    public void ToggleTransform() {
        if(!transformed) Dieify();
        else Personify();
    }

    public void Dieify() {
        if(transformed) return;

        transformed = true;
        animator.ResetTrigger("Personify");
        animator.SetTrigger("Dieify");
        animator.SetBool("Transformed", true);

        // Update player visuals and collider
        Vector2 pos = groundPoint.localPosition;
        Vector2 colSize = playerCollider.size;
        offset = playerCollider.offset;
        pos.y *= diceSize.y;
        colSize *= diceSize;

        // Update player movement stats
        move.maxAcceleration *= movementMultipliers[0];
        move.maxDecceleration *= movementMultipliers[0];
        move.maxTurnSpeed *= movementMultipliers[0];

        move.maxAirAcceleration *= movementMultipliers[1];
        move.maxAirDeceleration *= movementMultipliers[1];
        move.maxAirTurnSpeed *= movementMultipliers[1];

        // jump.jumpHeight *= movementMultipliers[2];

        move.maxSpeed *= movementMultipliers[3];

        groundPoint.localPosition = pos;
        playerCollider.size = colSize;
        playerCollider.offset = new Vector2();
    }

    public void Personify() {
        if(!transformed) return;

        transformed = false;
        animator.ResetTrigger("Dieify");
        animator.SetTrigger("Personify");
        animator.SetBool("Transformed", false);
        
        // Update player visuals and collider 
        Vector2 pos = groundPoint.localPosition;
        Vector2 colSize = playerCollider.size;
        pos.y /= diceSize.y;
        colSize /= diceSize;

        // Update player movement stats
        move.maxAcceleration /= movementMultipliers[0];
        move.maxDecceleration /= movementMultipliers[0];
        move.maxTurnSpeed /= movementMultipliers[0];

        move.maxAirAcceleration /= movementMultipliers[1];
        move.maxAirDeceleration /= movementMultipliers[1];
        move.maxAirTurnSpeed /= movementMultipliers[1];

        // jump.jumpHeight /= movementMultipliers[2];

        move.maxSpeed /= movementMultipliers[3];

        groundPoint.localPosition = pos;
        playerCollider.size = colSize;
        playerCollider.offset = offset;
    }

}
