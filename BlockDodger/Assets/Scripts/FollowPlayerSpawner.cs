using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerSpawner : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.transform.position);
    }

    private void FixedUpdate() {
        this.transform.position = new Vector3(offset.x, -4.4f + offset.y, player.position.z + offset.z);
        //Debug.Log(this.transform.position);
    }
}
