using UnityEngine;

public class JumpProjectile : RandomProjectile {
    public float spinSpeed = 2f;

    private Vector3 rotation;
    

    void Start() {
        power = 0;
        rotation = new Vector3(0, 0, spinSpeed);
    }

    void FixedUpdate() {
        transform.Rotate(rotation);
    }
}
