using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution1 : MonoBehaviour
{
    GlobalGameManager globalGameManager;
    // Start is called before the first frame update
    void Start()
    {
        globalGameManager = FindObjectOfType<GlobalGameManager>();
    }

    public void SetResolution1()
    {
        globalGameManager.resolutionSetting = 1;
        globalGameManager.setResolution();
    }
}
