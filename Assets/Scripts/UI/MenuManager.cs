using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    
    public bool mainMenu = false;
    public GameObject pauseMenu;
    private bool isPaused = false;

    void OnPause() {
        TogglePause();
    }

    public void Exit() {
        Application.Quit();
    }

    public void TogglePause() {
        if(mainMenu) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else {
            if(isPaused) Unpause();
            else Pause();
        }
    }

    private void Unpause() {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Pause() {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
