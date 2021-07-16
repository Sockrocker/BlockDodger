using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution4 : MonoBehaviour
{
    GlobalGameManager globalGameManager;
    // Start is called before the first frame update
    void Start()
    {
        globalGameManager = FindObjectOfType<GlobalGameManager>();
    }

    public void SetResolution4()
    {
        globalGameManager.resolutionSetting = 4;
        globalGameManager.setResolution();
    }
}
