using UnityEngine;

public class PlayerHurt : MonoBehaviour {
    private Vector2 respawnPoint;
    private PlayerTransform diceTransform;


    // Start is called before the first frame update
    void Start() {
        respawnPoint = transform.position;
        diceTransform = GetComponent<PlayerTransform>();
    }

    public void SetRespawn(Vector2 pos) {
        respawnPoint = pos;
    }
    
    public void Respawn() {
        diceTransform.Personify();
        transform.position = respawnPoint;
    }
}
