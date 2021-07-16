using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectReturn : MonoBehaviour
{
    MainMenuManager mainMenuManager;
    private void Start() {
        mainMenuManager = FindObjectOfType<MainMenuManager>();
    }

    public void ReturnToMainMenu()
    {
        mainMenuManager.OpenAndCloseLevelSelect();
        mainMenuManager.OpenAndCloseMainMenu();
    }
}
