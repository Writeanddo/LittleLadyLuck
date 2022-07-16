using UnityEngine;

public class Turret : MonoBehaviour {

    public float range = 15f;
    public float fireRate = 3f;
    public GameObject projectile;

    private Transform player;
    private float lastShot = -1;


    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update() {
        if(Time.time - lastShot > fireRate) {
            Vector2 toPlayer = player.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, toPlayer, range, LayerMask.GetMask("Player"));
            if(hit.collider != null) { // If Player is in range and line of sight
                Instantiate(projectile, transform.position, Quaternion.LookRotation(toPlayer));
                lastShot = Time.time;
            }
        }
    }
}
