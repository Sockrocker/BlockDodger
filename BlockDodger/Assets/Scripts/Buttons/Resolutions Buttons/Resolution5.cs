using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution5 : MonoBehaviour
{
    GlobalGameManager globalGameManager;
    // Start is called before the first frame update
    void Start()
    {
        globalGameManager = FindObjectOfType<GlobalGameManager>();
    }

    public void SetResolution5()
    {
        globalGameManager.resolutionSetting = 5;
        globalGameManager.setResolution();
    }
}
