using System.Collections;
using UnityEngine;

public class PlayerHurt : MonoBehaviour {
    private Vector2 respawnPoint;
    private PlayerTransform diceTransform;
    private PlayerJuice juice;
    private PlayerMovement move;
    private PlayerJump jump;

    private bool dying = false;


    // Start is called before the first frame update
    void Start() {
        respawnPoint = transform.position;
        diceTransform = GetComponent<PlayerTransform>();
        juice = GetComponent<PlayerJuice>();
        move = GetComponent<PlayerMovement>();
    }

    public void Die() {
        if(dying) return;

        dying = true;
        move.SetFrozen(true);
        juice.DeathEffects();
        StartCoroutine(DelayedRespawn(1));
    }

    public void SetRespawn(Vector2 pos) {
        respawnPoint = pos;
    }
    
    public void Respawn() {
        dying = false;
        move.SetFrozen(false);
        diceTransform.InstantPersonify();
        juice.RespawnEffects();
        transform.position = respawnPoint;
    }

    private IEnumerator DelayedRespawn(float duration) {
        yield return new WaitForSeconds(duration);
        Respawn();
    }
}
