using UnityEngine;

public class Hazard : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            other.gameObject.GetComponent<PlayerHurt>().Die();
        }
    }
}
