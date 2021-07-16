using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMainMenuButton : MonoBehaviour
{
    LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void Return()
    {
        levelManager.ReturnToMainMenu();
    }
}
