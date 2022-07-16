using UnityEngine;

//This script is used by both movement and jump to detect when the character is touching the ground

public class PlayerGround : MonoBehaviour
{
        private bool onGround;
       
        [Header("Collider Settings")]
        [SerializeField][Tooltip("Length of the ground-checking collider")] private float groundLengthOffset = 0.95f;
        [SerializeField][Tooltip("Length of the ground-checking collider")] private Transform groundPoint;
        [SerializeField][Tooltip("Distance between the ground-checking colliders")] private Vector3 colliderOffset;

        [Header("Layer Masks")]
        [SerializeField][Tooltip("Which layers are read as the ground")] private LayerMask groundLayer;
 

        private void Update() {
            //Determine if the player is stood on objects on the ground layer, using a pair of raycasts
            float groundLength = -groundPoint.localPosition.y + groundLengthOffset;
            onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);
        }

        private void OnDrawGizmos() {
            //Draw the ground colliders on screen for debug purposes
            float groundLength = -groundPoint.localPosition.y + groundLengthOffset;
            if (onGround) { Gizmos.color = Color.green; } else { Gizmos.color = Color.red; }
            Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
            Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
        }

        //Send ground detection to other scripts
        public bool GetOnGround() { return onGround; }
}