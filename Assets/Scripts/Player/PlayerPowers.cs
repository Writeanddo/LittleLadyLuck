using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPowers : MonoBehaviour {

    public float peakThreshold = 0.5f;

    // 0 = Jump, 1 = Dash, 2 = Transform
    public List<UnityEvent> powers;

    private PlayerTransform diceTransform;
    private PlayerGround ground;
    private PlayerMovement move;
    private Rigidbody2D body;

    private int currPower = -1;
    private int lastPower = -1;

    void Start() {
        diceTransform = GetComponent<PlayerTransform>();

        ground = GetComponent<PlayerGround>();
        body = GetComponent<Rigidbody2D>();
        move = GetComponent<PlayerMovement>();
        // jump = GetComponent<PlayerJump>();
    }

    void OnShift() {
        if(move.frozen) return;

        if(!diceTransform.IsTransformed()) ChoosePower();
        else { // If we're in the middle of using a power
            if(currPower == 2) { // If we're currently transformed
                diceTransform.Personify();
            }
        }
    }
    
    private void ChoosePower() {
        Vector2 velocity = body.velocity;
        bool grounded = ground.GetOnGround();

        if(grounded) {
            RandomPower();
        } else {
            if(velocity.y > peakThreshold) { // If we're rising
                StartPower(0); // Jump
            } else if(velocity.y < -peakThreshold) { // If we're falling
                StartPower(2); // Transform
            } else { // If we're at the peak
                StartPower(1); // Dash
            }
        }
    }

    public void RandomPower() {
        Debug.Log("Random");
        if(diceTransform.IsTransformed()) return; // Skip if we're already in a power

        int rand;

        if(lastPower == -1) rand = Random.Range(0, powers.Count);
        else {
            rand = Random.Range(0, powers.Count - 1);
            if(rand >= lastPower) rand++;
        }

        StartPower(rand);
        lastPower = rand;
    }

    public void TriggerPower(int power) {
        if(diceTransform.IsTransformed()) return; // Skip if we're already in a power
        StartPower(power);
    }

    private void StartPower(int power) {
        currPower = power;
        powers[power].Invoke();
    }
}
