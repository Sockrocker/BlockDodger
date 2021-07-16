using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject orbPrefab;
    public float orbSpawnDelayTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnOrbs());
    }

    IEnumerator SpawnOrbs()
    {
        Instantiate(orbPrefab, spawnPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(orbSpawnDelayTime);
        StartCoroutine(SpawnOrbs());
    }
}
