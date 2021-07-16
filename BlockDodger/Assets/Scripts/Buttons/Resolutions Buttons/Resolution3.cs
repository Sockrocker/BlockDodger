using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution3 : MonoBehaviour
{
    GlobalGameManager globalGameManager;
    // Start is called before the first frame update
    void Start()
    {
        globalGameManager = FindObjectOfType<GlobalGameManager>();
    }

    public void SetResolution3()
    {
        globalGameManager.resolutionSetting = 3;
        globalGameManager.setResolution();
    }
}
