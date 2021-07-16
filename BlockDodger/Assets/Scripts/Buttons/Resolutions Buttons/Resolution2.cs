using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution2 : MonoBehaviour
{
    GlobalGameManager globalGameManager;
    // Start is called before the first frame update
    void Start()
    {
        globalGameManager = FindObjectOfType<GlobalGameManager>();
    }

    public void SetResolution2()
    {
        globalGameManager.resolutionSetting = 2;
        globalGameManager.setResolution();
    }
}
