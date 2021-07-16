using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportCooldownUI : MonoBehaviour
{
    PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        setCooldownColor();
    }

    public void setCooldownColor()
    {
        if(player.canTeleport)
        {
            this.GetComponent<Image>().color = Color.green;
        }
        else
        {
            this.GetComponent<Image>().color = Color.red;
        }
    }
}
