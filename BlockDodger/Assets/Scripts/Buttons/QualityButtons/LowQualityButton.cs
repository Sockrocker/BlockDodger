using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowQualityButton : MonoBehaviour
{
    GlobalGameManager globalGameManager;
    // Start is called before the first frame update
    void Start()
    {
        globalGameManager = FindObjectOfType<GlobalGameManager>();
    }

    public void SetLowQuality()
    {
        globalGameManager.qualityLevel = "Low";
        globalGameManager.setQualityLevel();
    }
}
