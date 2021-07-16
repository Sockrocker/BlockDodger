using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    GlobalGameManager globalGameManager;
    public int level;
    public string levelTitle;
    AsyncOperation asyncOperation;
    // Start is called before the first frame update
    void Start()
    {
        globalGameManager = FindObjectOfType<GlobalGameManager>();
        if (!globalGameManager.levelCheck[level - 1])
        {
            this.gameObject.SetActive(false);
        }
        ButtonTitle();
        //asyncOperation = SceneManager.LoadSceneAsync(level);
        //asyncOperation.allowSceneActivation = false;
    }
    private void Update() {
        //Debug.Log(SceneManager.sceneCount);
        //Debug.Log(asyncOperation.progress);
        if (asyncOperation != null)
        {
            if (asyncOperation.isDone)
            {
                asyncOperation.allowSceneActivation = true;
            }
        }
    }

    public void ButtonTitle()
    {
        this.GetComponentInChildren<TMP_Text>().text = "Level " + levelTitle + " \n" + "High Score: " + globalGameManager.highScore[level -1];
    }

    public void OnPressedLevelButton()
    {
        //SceneManager.LoadScene("Level0" + level);
        //Debug.Log(SceneManager.sceneCount);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(level));
        asyncOperation = SceneManager.LoadSceneAsync(level);
        asyncOperation.allowSceneActivation = true;
        /*if (asyncOperation.isDone)
        {
            asyncOperation.allowSceneActivation = true;
        }*/
    }
}
