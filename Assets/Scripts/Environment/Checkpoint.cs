using UnityEngine;

public class Checkpoint : MonoBehaviour {
    public float deltaSpin = 0.1f;
    public Vector2 spinSpeedRange;

    public float spin;
    void Update() {
        if(spin > 0) {
            transform.Rotate(new Vector3(0, 0, spin));
            spin -= deltaSpin * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerHurt>().SetRespawn(transform.position);
            spin = Random.Range(spinSpeedRange[0], spinSpeedRange[1]);
        }
    }
}
