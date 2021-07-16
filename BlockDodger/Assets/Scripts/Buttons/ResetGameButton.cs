using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameButton : MonoBehaviour
{
    GlobalGameManager globalGameManager;
    // Start is called before the first frame update
    void Start()
    {
        globalGameManager = FindObjectOfType<GlobalGameManager>();
    }

    public void ResetGameState()
    {
        globalGameManager.resetGameState = true;
    }
}
