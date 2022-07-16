using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") NextScene();
    }

    private void NextScene() {
        int nextScene = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextScene);
    }
}
