using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Rigidbody player;
    LevelManager levelManager;

    // Start is called before the first frame update
    private void Start() 
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Obstacle")
        {
            StartCoroutine(levelManager.FailedLevel());
        }
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "GoalPost")
        {
            StartCoroutine(levelManager.EndLevel());
        }
    }
}
