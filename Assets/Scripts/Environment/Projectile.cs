using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed = 3f;
    

    void Awake() {
        Vector3 toPlayer = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        transform.right = toPlayer;
        GetComponent<Rigidbody2D>().velocity = toPlayer.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerPowers>().RandomPower();
        }

        if(other.gameObject.layer != LayerMask.NameToLayer("Hazards")) Destroy(gameObject);
    }
}
