using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update() {
        if (!Input.GetKeyDown(KeyCode.Escape)) {
            return;
        }

        if (GamePaused) {
            Resume();
        } else {
            Pause();
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        GamePaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SaveGame() {
        Debug.Log("TODO: Plugin Danielle's saving system");
        // TODO: Plugin Danielle's saving system
    }
    
    public void QuitGame() {
        Time.timeScale = 1f;
        GamePaused = false;
        SceneManager.LoadScene("StartMenu");
        Debug.Log("Quitting...");
    }
}