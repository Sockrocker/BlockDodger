using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultResolutionButton : MonoBehaviour
{
    GlobalGameManager globalGameManager;
    // Start is called before the first frame update
    void Start()
    {
        globalGameManager = FindObjectOfType<GlobalGameManager>();
    }

    public void SetDefaultResolution()
    {
        globalGameManager.resolutionSetting = 0;
        globalGameManager.setResolution();
    }
}
