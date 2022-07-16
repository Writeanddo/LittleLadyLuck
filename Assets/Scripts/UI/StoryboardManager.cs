using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryboardManager : MonoBehaviour {
    public List<Sprite> sprites;
    public List<float> durations;
    public List<float> zooms;

    private Image image;
    private int index = -1;
    private float nextChange = -1;
    private float zoomStart = 1, zoomEnd = 1;

    void Start() {
        image = GetComponent<Image>();
    }
    
    void Update() {
        if(Time.time > nextChange) {
            index++;
            if(index == sprites.Count) NextScene();
            else NewSlide(index);
        } else {
            float perc = 1 - ((nextChange - Time.time) / durations[index]);
            transform.localScale = Vector3.one * Mathf.SmoothStep(zoomStart, zoomEnd, perc);
        }
    }

    void OnPause() {
        NextScene();
    }

    void NewSlide(int i) {
        nextChange = Time.time + durations[i];
        image.sprite = sprites[i];
        if(zooms[i] >= 1) {
            zoomStart = 1;
            zoomEnd = zooms[i];
        } else {
            zoomStart = 1 / zooms[i];
            zoomEnd = 1;
        }
        
        transform.localScale = Vector3.one * zoomStart;
    }

    private void NextScene() {
        int nextScene = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextScene);
    }
}
