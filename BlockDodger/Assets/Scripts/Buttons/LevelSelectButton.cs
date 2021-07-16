using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    MainMenuManager mainMenuManager;
    // Start is called before the first frame update
    void Start()
    {
        mainMenuManager = FindObjectOfType<MainMenuManager>();
    }

    public void OpenLevelSelect()
    {
        mainMenuManager.OpenAndCloseMainMenu();
        mainMenuManager.OpenAndCloseLevelSelect();
    }
}
