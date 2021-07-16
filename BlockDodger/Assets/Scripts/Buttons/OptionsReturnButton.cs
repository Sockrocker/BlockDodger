using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsReturnButton : MonoBehaviour
{
    MainMenuManager mainMenuManager;

    private void Start() {
        mainMenuManager = FindObjectOfType<MainMenuManager>();
    }
    public void ReturnToMainMenu()
    {
        mainMenuManager.OpenAndCloseOptionsMenu();
        mainMenuManager.OpenAndCloseMainMenu();
    }
}
