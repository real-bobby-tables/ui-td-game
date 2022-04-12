using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject levelSettingsMenu;
    public GameObject startMenu;
    static bool isGamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }


    public void loadLevel(int level) {
        SceneManager.LoadScene(level);
    }

    public void startGame() {
        loadLevel(1);
    }

    public void exitGame() {
        Application.Quit();
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    private void changeMenu(GameObject fromMenu, GameObject toMenu) {
        fromMenu.SetActive(false);
        toMenu.SetActive(true);
    }

    public void loadLevelSettings() {
        changeMenu(startMenu, levelSettingsMenu);
    }

    public void loadMainFromLevel() {
        changeMenu(levelSettingsMenu, startMenu);
    }
}
