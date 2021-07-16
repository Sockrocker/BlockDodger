using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Speed : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public TMP_Text speedText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = playerMovement.playerSpeed.ToString();
    }
}
