using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameButton : MonoBehaviour
{
    GlobalGameManager globalGameManager;
    // Start is called before the first frame update
    void Start()
    {
        globalGameManager = FindObjectOfType<GlobalGameManager>();
    }

    public void PlayGame()
    {
        globalGameManager.setGameSpeed();
        SceneManager.LoadScene(globalGameManager.nextLevel);
    }

}
