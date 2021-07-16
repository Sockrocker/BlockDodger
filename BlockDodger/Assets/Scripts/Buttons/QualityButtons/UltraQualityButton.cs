using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraQualityButton : MonoBehaviour
{
    GlobalGameManager globalGameManager;
    // Start is called before the first frame update
    void Start()
    {
        globalGameManager = FindObjectOfType<GlobalGameManager>();
    }

    public void SetUltraQuality()
    {
        globalGameManager.qualityLevel = "Ultra";
        globalGameManager.setQualityLevel();
    }
}
