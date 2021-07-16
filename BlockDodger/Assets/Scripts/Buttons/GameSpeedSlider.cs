using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedSlider : MonoBehaviour
{
    GlobalGameManager globalGameManager;
    // Start is called before the first frame update
    void Start()
    {
        globalGameManager = FindObjectOfType<GlobalGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnValueChanged(float value)
    {
        globalGameManager.gameSpeed = value;
        globalGameManager.setGameSpeed();
    }
}
