using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public float range = 15f;
    public float fireRate = 3f;
    public List<GameObject> projectiles;
    public LayerMask visibleObjects;

    private Transform player;
    private float lastShot = -1;
    private List<int> sequence;
    private Vector2 direction;


    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sequence = GeneratePermutation();

        if(transform.childCount > 0) direction = transform.GetChild(0).transform.position - transform.position;
        else direction = Vector2.zero;
    }
    
    void Update() {
        if(Time.time - lastShot > fireRate) {
            Vector2 toPlayer = player.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, toPlayer, range, visibleObjects);
            if(range == -1 || (hit.collider != null && hit.collider.tag == "Player")) { // If Player is in range and line of sight
                GameObject proj = Instantiate(RandomProj(), transform.position, Quaternion.identity);
                if(direction != Vector2.zero) proj.GetComponent<RandomProjectile>().SetDirection(direction);
                lastShot = Time.time;
            }
        }
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private GameObject RandomProj() {
        if(sequence.Count == 0) sequence.AddRange(GeneratePermutation());

        int type = sequence[0];
        sequence.RemoveAt(0);
        return projectiles[type];
    }

    private List<int> GeneratePermutation() {
        int n = projectiles.Count;
        int[] array = new int[n];
        for (int i = 0; i < n; i++) array[i] = i;
        Shuffle(array);

        return new List<int>(array);
    }

    private void Shuffle(int[] array) {
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int i = Random.Range(0, n + 1);
            int temp = array[i];
            array[i] = array[n];
            array[n] = temp;
    }
    }
}
