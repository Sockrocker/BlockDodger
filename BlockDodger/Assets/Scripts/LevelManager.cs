using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    GlobalGameManager globalGameManager;
    public bool isGamePaused;
    public Rigidbody player;
    public int score;
    public int orbScore;
    public int highScore;
    public GameObject pauseMenu;
    public float levelDelayTime = 2f;
    public GameObject failMessage;
    public GameObject winMessage;

    private Transform playerCurrentLocation;
    private Vector3 playerStartLocation;

    // Start is called before the first frame update
    void Start()
    {
        globalGameManager = FindObjectOfType<GlobalGameManager>();
        GetCurrentLevel();
        GetNextLevel();
        globalGameManager.levelCheck[SceneManager.GetActiveScene().buildIndex - 1] = true;
        highScore = globalGameManager.highScore[SceneManager.GetActiveScene().buildIndex - 1];
        playerStartLocation = player.transform.position;
        playerCurrentLocation = player.transform;
        globalGameManager.setGameSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        score = -(int)(playerCurrentLocation.position.z - playerStartLocation.z) + orbScore;
    }

    private void GetCurrentLevel()
    {
        globalGameManager.currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
    }

    private void GetNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex != 15)
        {
            globalGameManager.nextLevel = SceneManager.GetActiveScene().buildIndex;
        }
        else
        {
            globalGameManager.nextLevel = 0;
        }
    }

    public void PauseGame()
    {
        if(!isGamePaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isGamePaused = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = globalGameManager.gameSpeed;
            isGamePaused = false;
        }
    }

    public void RestartLevel()
    {
        globalGameManager.setGameSpeed();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateHighScore()
    {
        highScore = Mathf.Max(score, highScore);
        globalGameManager.highScore[globalGameManager.currentLevel] = Mathf.Max(highScore, globalGameManager.highScore[globalGameManager.currentLevel]);
    }

    public void ReturnToMainMenu()
    {
        /*Scene scene = SceneManager.GetSceneByName("Main Menu");
        if (scene != null)
        {
            Debug.Log(scene);
        }*/
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MainMenu");
        if (asyncOperation.isDone)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainMenu"));
        }
    }

    public IEnumerator EndLevel()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(globalGameManager.nextLevel + 1);
        UpdateHighScore();
        Time.timeScale = globalGameManager.gameSpeed / 2;
        winMessage.SetActive(true);
        yield return new WaitForSeconds(levelDelayTime);
        globalGameManager.setGameSpeed();
        //SceneManager.LoadScene(globalGameManager.nextLevel + 1);
        if (asyncOperation.isDone)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(globalGameManager.nextLevel + 1));
        }
    }

    public IEnumerator FailedLevel()
    {
        //AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(globalGameManager.currentLevel + 1);
        UpdateHighScore();
        Time.timeScale = globalGameManager.gameSpeed / 2;
        failMessage.SetActive(true);
        yield return new WaitForSeconds(levelDelayTime);
        globalGameManager.setGameSpeed();
        SceneManager.LoadScene(globalGameManager.currentLevel + 1);
    }
}
