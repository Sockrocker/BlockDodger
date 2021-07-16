using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighQualityButton : MonoBehaviour
{
    GlobalGameManager globalGameManager;
    // Start is called before the first frame update
    void Start()
    {
        globalGameManager = FindObjectOfType<GlobalGameManager>();
    }

    public void SetHighQuality()
    {
        globalGameManager.qualityLevel = "High";
        globalGameManager.setQualityLevel();
    }
}
