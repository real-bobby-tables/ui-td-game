using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject controlMenu;
    public GameObject levelSettingsMenu;
    public GameObject startMenu;

    public void loadLevel(int level) {
        SceneManager.LoadScene(level);
    }

    public void startGame() {
        loadLevel(1);
    }

    public void exitGame() {
        Application.Quit();
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
