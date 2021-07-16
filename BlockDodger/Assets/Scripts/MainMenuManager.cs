using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject levelSelectMenu;
    public GameObject creditsMenu;

    private bool isMainMenuOpen;
    private bool isOptionsMenuOpen;
    private bool isLevelSelectOpen;
    private bool isCreditsOpen;
    private GlobalGameManager globalGameManager;
    // Start is called before the first frame update
    void Start()
    {
        globalGameManager = FindObjectOfType<GlobalGameManager>();
        isMainMenuOpen = true;
        globalGameManager.currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (globalGameManager.nextLevel == 0)
        {
            globalGameManager.nextLevel = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenAndCloseMainMenu()
    {
        if (isMainMenuOpen)
        {
            mainMenu.SetActive(false);
            isMainMenuOpen = false;
        }
        else
        {
            mainMenu.SetActive(true);
            isMainMenuOpen = true;
        }
    }
    public void OpenAndCloseOptionsMenu()
    {
        if (isOptionsMenuOpen)
        {
            optionsMenu.SetActive(false);
            isOptionsMenuOpen = false;
        }
        else
        {
            optionsMenu.SetActive(true);
            isOptionsMenuOpen = true;
        }
    }
    public void OpenAndCloseLevelSelect()
    {
        if (isLevelSelectOpen)
        {
            levelSelectMenu.SetActive(false);
            isLevelSelectOpen = false;
        }
        else
        {
            levelSelectMenu.SetActive(true);
            isLevelSelectOpen = true;
        }
    }
    public void OpenAndCloseCredits()
    {
        if (isCreditsOpen)
        {
            creditsMenu.SetActive(false);
            isCreditsOpen = false;
        }
        else
        {
            creditsMenu.SetActive(true);
            isCreditsOpen = true;
        }
    }
}
