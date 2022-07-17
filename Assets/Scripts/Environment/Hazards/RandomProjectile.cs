using UnityEngine;

public class RandomProjectile : MonoBehaviour {
    public float speed = 3f;
    public LayerMask destroy;
    protected int power = -1; // -1 = Random, 0-2 = real powers
    

    void Awake() {
        Vector3 toPlayer = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        GetComponent<Rigidbody2D>().velocity = toPlayer.normalized * speed;
    }

    public void SetDirection(Vector2 direction) {
        GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            if(power == -1) other.gameObject.GetComponent<PlayerPowers>().RandomPower();
            else other.gameObject.GetComponent<PlayerPowers>().TriggerPower(power);
        }

        if((destroy.value & (1<<other.gameObject.layer)) != 0) Destroy(gameObject);
    }
}
