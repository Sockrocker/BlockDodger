using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalGameManager : MonoBehaviour
{
    public static GlobalGameManager Instance;

    [Space]

    [Header("Game State")]
    //Bool value for if the player has gotten to a level or not.
    public int currentLevel;
    public int nextLevel;
    public bool[] levelCheck = new bool[15];
    //Bool value for if the player has played the game or not.
    public bool hasPlayedGame;
    //Bool value for resetting game state.
    public bool resetGameState = false;
    public int[] highScore = new int[15];
    public bool shouldGameBeSaved = true;


    [Space]

    [Header("Accessibility")]
    //Bool value for colorblindness options (if true, black and white)
    [Range(0.5f, 1f)]
    public float gameSpeed = 1f;

    //String for level of quality:
    //"Low" = Low
    //"Medium" = Medium, etc.
    //QualitySettings.SetQualityLevel(0) = Low
    public string qualityLevel;

    //Int for setting resolution:
    //0 = default (1920 x 1080)
    //1 = 1600 x 900
    //2 = 1280 x 800
    //3 = 1024 x 768
    //4 = 800 x 600
    //5 = 640 x 480
    //Screen.SetResolution()
    public int resolutionSetting;
    public bool fullScreen;

    void Awake() 
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        if(intToBool(PlayerPrefs.GetInt("HasPlayedGame")))
        {
            loadSaveData();
        }
        else
        {
            hasPlayedGame = true;
            currentLevel = 0;
            nextLevel = 1;
            saveData();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoSave());
        resolutionSetting = 0;
        fullScreen = true;
        setResolution();

    }

    // Update is called once per frame
    void Update()
    {
        if (resetGameState)
        {
            resetSaveData();
        }
        if (shouldGameBeSaved)
        {
            saveData();
            shouldGameBeSaved = false;
        }
    }

    public void saveData()
    {
        //Base Game Save Data
        for (int i = 0; i < levelCheck.Length; i++)
        {
            string savePos = "LevelCheck" + i.ToString();
            PlayerPrefs.SetInt(savePos, boolToInt(levelCheck[i]));
        }
        PlayerPrefs.SetInt("HasPlayedGame", boolToInt(hasPlayedGame));
        //PlayerPrefs.SetInt("ResetGameState", boolToInt(resetGameState));
        for (int i = 0; i < highScore.Length; i++)
        {
            string savePos = "HighScore" + i.ToString();
            PlayerPrefs.SetInt(savePos, highScore[i]);
        }

        //Accessibility
        PlayerPrefs.SetFloat("GameSpeed", gameSpeed);
        PlayerPrefs.SetString("QualityLevel", qualityLevel);
        PlayerPrefs.SetInt("Resolution", resolutionSetting);
        PlayerPrefs.SetInt("FullScreen", boolToInt(fullScreen));
        //Saves next level into playerprefs
        PlayerPrefs.SetInt("NextLevel", nextLevel);
    }

    
    public void loadSaveData()
    {
        //Base Game Save Data
        for (int i = 0; i < levelCheck.Length; i++)
        {
            string savePos = "LevelCheck" + i.ToString();
            levelCheck[i] = intToBool(PlayerPrefs.GetInt(savePos));
        }
        hasPlayedGame = intToBool(PlayerPrefs.GetInt("HasPlayedGame"));
        //PlayerPrefs.SetInt("ResetGameState", boolToInt(resetGameState));
        for (int i = 0; i < highScore.Length; i++)
        {
            string savePos = "HighScore" + i.ToString();
            highScore[i] = PlayerPrefs.GetInt(savePos);
        }

        //Accessibility
        gameSpeed = PlayerPrefs.GetFloat("GameSpeed");
        qualityLevel = PlayerPrefs.GetString("QualityLevel");
        resolutionSetting = PlayerPrefs.GetInt("Resolution");
        fullScreen = intToBool(PlayerPrefs.GetInt("FullScreen"));
        //Loads next level into playerprefs
        nextLevel = PlayerPrefs.GetInt("NextLevel", nextLevel);
    }

    public void setGameSpeed()
    {
        Time.timeScale = gameSpeed;
    }

    public void setQualityLevel()
    {
        switch (qualityLevel)
        {
            case "Low":
                QualitySettings.SetQualityLevel(0);
                break;
            case "Medium":
                QualitySettings.SetQualityLevel(1);
                break;
            case "High":
                QualitySettings.SetQualityLevel(2);
                break;
            case "Ultra":
                QualitySettings.SetQualityLevel(3);
                break;
            case "Super":
                QualitySettings.SetQualityLevel(4);
                break;
        }
    }

    public void setResolution()
    {
        //Int for setting resolution:
        //0 = default (1920 x 1080)
        //1 = 1600 x 900
        //2 = 1280 x 800
        //3 = 1024 x 768
        //4 = 800 x 600
        //5 = 640 x 480
        if (fullScreen)
        {
            switch (resolutionSetting)
            {
                case 0:
                    Screen.SetResolution(1920, 1080, true, 30);
                    break;
                case 1:
                    Screen.SetResolution(1600, 900, true, 30);
                    break;
                case 2:
                    Screen.SetResolution(1280, 800, true, 30);
                    break;
                case 3:
                    Screen.SetResolution(1024, 768, true, 30);
                    break;
                case 4:
                    Screen.SetResolution(800, 600, true, 30);
                    break;
                case 5:
                    Screen.SetResolution(640, 480, true, 30);
                    break;
            } 
        }
        else
        {
            switch (resolutionSetting)
            {
                case 0:
                    Screen.SetResolution(1920, 1080, false, 30);
                    break;
                case 1:
                    Screen.SetResolution(1600, 900, false, 30);
                    break;
                case 2:
                    Screen.SetResolution(1280, 800, false, 30);
                    break;
                case 3:
                    Screen.SetResolution(1024, 768, false, 30);
                    break;
                case 4:
                    Screen.SetResolution(800, 600, false, 30);
                    break;
                case 5:
                    Screen.SetResolution(640, 480, false, 30);
                    break;
            } 
        }
    }

    IEnumerator AutoSave()
    {
        //saveData();
        yield return new WaitForSeconds(300);
        shouldGameBeSaved = true;
        StartCoroutine(AutoSave());
    }

    public void resetSaveData()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public int boolToInt(bool value)
    {
        if (value)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public bool intToBool(int value)
    {
        if (value == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
