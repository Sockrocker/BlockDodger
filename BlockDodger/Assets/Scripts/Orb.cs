using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Orb : MonoBehaviour
{
    LevelManager levelManager;
    GameObject orbScoreMessage;

    private void Start() {
        levelManager = FindObjectOfType<LevelManager>();
        orbScoreMessage = GameObject.FindGameObjectWithTag("OrbPlus");
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            levelManager.orbScore += 100;
            StartCoroutine(OrbScore());
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    IEnumerator OrbScore()
    {
        orbScoreMessage.GetComponent<TMP_Text>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        orbScoreMessage.GetComponent<TMP_Text>().enabled = false;
        //Debug.Log("Test");
        Destroy(this.gameObject);
    }
}
