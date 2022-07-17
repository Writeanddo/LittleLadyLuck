using UnityEngine;

public class Blip : MonoBehaviour {
    public GameObject box;
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") ShowDialog();
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") HideDialog();
    }

    void ShowDialog() {
        box.SetActive(true);
    }

    void HideDialog() {
        box.SetActive(false);
    }
}
