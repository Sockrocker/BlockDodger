using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDeleter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Orb")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Orb")
        {
            Destroy(other.gameObject);
        }
    }
}
