using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [Header("Base Required Components")]
    public GameObject[] spawnPoints;
    public GameObject obstaclePrefab;
    [Space]
    [Header("Spawn Delays")]
    public float levelOneSpawnDelay = 2f;
    public float levelTwoSpawnDelay = 2f;
    public float levelThreeSpawnDelay = 2f;
    public float levelFourSpawnDelay = 2f;
    public float levelFiveSpawnDelay = 1f;
    public float levelSixSpawnDelay = 1f;
    public float levelSevenSpawnDelay = 5f;
    public float levelEightSpawnDelay = 4f;
    public float levelNineSpawnDelay = 3f;
    public float levelTenSpawnDelay = 5f;
    public float levelElevenSpawnDelay = 5f;
    public float levelTwelveSpawnDelay = 4f;
    public float levelThirteenSpawnDelay = 5f;
    public float levelFourteenSpawnDelay = 4f;
    public float levelFifteenSpawnDelay = 3f;

    private GlobalGameManager globalGameManager;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Level started, spawning obstacles...");
        globalGameManager = FindObjectOfType<GlobalGameManager>();
        //Debug.Log(globalGameManager.currentLevel);
        if (globalGameManager.currentLevel == 0)
        {
            StartCoroutine(SpawnObstaclesLevelOne());
        }
        if (globalGameManager.currentLevel == 1)
        {
            StartCoroutine(SpawnObstaclesLevelTwo());
        }
        if (globalGameManager.currentLevel == 2)
        {
            StartCoroutine(SpawnObstaclesLevelThree());
        }
        if (globalGameManager.currentLevel == 3)
        {
            StartCoroutine(SpawnObstaclesLevelFour());
        }
        if (globalGameManager.currentLevel == 4)
        {
            StartCoroutine(SpawnObstaclesLevelFive());
        }
        if (globalGameManager.currentLevel == 5)
        {
            StartCoroutine(SpawnObstaclesLevelSix());
        }
        if (globalGameManager.currentLevel == 6)
        {
            StartCoroutine(SpawnObstaclesLevelSeven());
        }
        if (globalGameManager.currentLevel == 7)
        {
            StartCoroutine(SpawnObstaclesLevelEight());
        }
        if (globalGameManager.currentLevel == 8)
        {
            StartCoroutine(SpawnObstaclesLevelNine());
        }
        if (globalGameManager.currentLevel == 9)
        {
            StartCoroutine(SpawnObstaclesLevelTen());
        }
        if (globalGameManager.currentLevel == 10)
        {
            StartCoroutine(SpawnObstaclesLevelEleven());
        }
        if (globalGameManager.currentLevel == 11)
        {
            StartCoroutine(SpawnObstaclesLevelTwelve());
        }
        if (globalGameManager.currentLevel == 12)
        {
            StartCoroutine(SpawnObstaclesLevelThirteen());
        }
        if (globalGameManager.currentLevel == 13)
        {
            StartCoroutine(SpawnObstaclesLevelFourteen());
        }
        if (globalGameManager.currentLevel == 14)
        {
            StartCoroutine(SpawnObstaclesLevelFifteen());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstaclesLevelOne()
    {
        int spawn = (int)Random.Range(0, 9);
        //Debug.Log(spawn);
        Vector3 spawnLocation = new Vector3(
            spawnPoints[spawn].transform.position.x,
             spawnPoints[spawn].transform.position.y,
              spawnPoints[spawn].transform.position.z
              );
        //Debug.Log(spawnPoints[spawn].name);
        //Starts doing what I want it to do, but doesn't continue doing that. Unknown glitch.
        //Debug.Log(spawnPoints[spawn].transform.position.x);
        Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
        yield return new WaitForSeconds(levelOneSpawnDelay);
        StartCoroutine(SpawnObstaclesLevelOne());
        //Debug.Log("Spawning Obstacles...");
    }

    IEnumerator SpawnObstaclesLevelTwo()
    {
        int spawn = (int)Random.Range(1, 8);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != spawn && i != spawn - 1 && i != spawn + 1)
            {
                Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
            }
        }
        yield return new WaitForSeconds(levelTwoSpawnDelay);
        StartCoroutine(SpawnObstaclesLevelTwo());
    }

    IEnumerator SpawnObstaclesLevelThree()
    {
        int spawn = (int)Random.Range(0, 9);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != spawn)
            {
                Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
            }
        }
        yield return new WaitForSeconds(levelThreeSpawnDelay);
        StartCoroutine(SpawnObstaclesLevelThree());
    }

    IEnumerator SpawnObstaclesLevelFour()
    {
        int spawn = (int)Random.Range(0,2);
        for (int i = 0; i< spawnPoints.Length; i++)
        {
            if (spawn == 0)
            {
                Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
            }
            if (spawn == 1)
            {
                Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
            }
        }
        yield return new WaitForSeconds(levelFourSpawnDelay);
        StartCoroutine(SpawnObstaclesLevelFour());
    }

    IEnumerator SpawnObstaclesLevelFive()
    {
        int spawn = (int)Random.Range(0,2);
        for (int i = 0; i< spawnPoints.Length; i++)
        {
            if (spawn == 0)
            {
                Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
            }
            if (spawn == 1)
            {
                Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
            }
        }
        yield return new WaitForSeconds(levelFiveSpawnDelay);
        StartCoroutine(SpawnObstaclesLevelFive());
    }

    IEnumerator SpawnObstaclesLevelSix()
    {
        int spawn = Random.Range(1, 8);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != spawn && i != spawn - 1 && i != spawn + 1)
            {
                Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                Vector3 spawnLocation2 = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation2, Quaternion.identity);
            }
        }
        yield return new WaitForSeconds(levelSixSpawnDelay);
        StartCoroutine(SpawnObstaclesLevelSix());
    }

    IEnumerator SpawnObstaclesLevelSeven()
    {
        int spawn = Random.Range(0, 2);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i!= spawn && i != spawn + 2 && i != spawn + 4 && i != spawn + 6 && i != spawn + 8)
            {
                Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                Vector3 spawnLocation2 = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation2, Quaternion.identity);
            }
        }
        yield return new WaitForSeconds(levelSevenSpawnDelay);
        StartCoroutine(SpawnObstaclesLevelSeven());
    }
    IEnumerator SpawnObstaclesLevelEight()
    {
        int spawn = Random.Range(0, 2);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != spawn - 2 && i!= spawn && i != spawn + 2 && i != spawn + 4 && i != spawn + 6 && i != spawn + 8)
            {
                Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                Vector3 spawnLocation2 = new Vector3(
                    spawnPoints[i].transform.position.x - 1,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation2, Quaternion.identity);
            }
        }
        yield return new WaitForSeconds(levelEightSpawnDelay);
        StartCoroutine(SpawnObstaclesLevelEight());
    }
    IEnumerator SpawnObstaclesLevelNine()
    {
        int spawn = Random.Range(0, 2);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != spawn - 2 && i!= spawn && i != spawn + 2 && i != spawn + 4 && i != spawn + 6 && i != spawn + 8)
            {
                Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                Vector3 spawnLocation2 = new Vector3(
                    spawnPoints[i].transform.position.x - 1,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation2, Quaternion.identity);
            }
        }
        yield return new WaitForSeconds(levelNineSpawnDelay);
        StartCoroutine(SpawnObstaclesLevelNine());
    }

    IEnumerator SpawnObstaclesLevelTen()
    {
        int spawn = Random.Range(0, 8);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != spawn - 1 && i != spawn && i != spawn + 1)
            {
                Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                Vector3 spawnLocation2 = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation2, Quaternion.identity);
            }
            else
            {
                int spawnNumber2 = Random.Range(0,2);
                if (spawnNumber2 == 0)
                {
                    Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                }
                if (spawnNumber2 == 1)
                {
                    Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                }
            }
        }
        yield return new WaitForSeconds(levelTenSpawnDelay);
        StartCoroutine(SpawnObstaclesLevelTen());
    }

    IEnumerator SpawnObstaclesLevelEleven()
    {
        int spawn = Random.Range(0, 8);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != spawn && i != spawn + 1)
            {
                Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                Vector3 spawnLocation2 = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation2, Quaternion.identity);
            }
            else
            {
                int spawnNumber2 = Random.Range(0,2);
                if (spawnNumber2 == 0)
                {
                    Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                }
                if (spawnNumber2 == 1)
                {
                    Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                }
                
            }
        }
        yield return new WaitForSeconds(levelElevenSpawnDelay);
        StartCoroutine(SpawnObstaclesLevelEleven());
    }

    IEnumerator SpawnObstaclesLevelTwelve()
    {
        int spawn = Random.Range(0, 9);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != spawn)
            {
                Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                Vector3 spawnLocation2 = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation2, Quaternion.identity);
            }
            else
            {
                int spawnNumber2 = Random.Range(0,2);
                if (spawnNumber2 == 0)
                {
                    Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                }
                if (spawnNumber2 == 1)
                {
                    Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                }
                
            }
        }
        yield return new WaitForSeconds(levelTwelveSpawnDelay);
        StartCoroutine(SpawnObstaclesLevelTwelve());
    }

    IEnumerator SpawnObstaclesLevelThirteen()
    {
        int spawn = Random.Range(0, 8);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != spawn - 1 && i != spawn && i != spawn + 1)
            {
                Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                Vector3 spawnLocation2 = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation2, Quaternion.identity);
            }
            else
            {
                int spawnNumber2 = Random.Range(0,2);
                if (spawnNumber2 == 0)
                {
                    Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                }
                if (spawnNumber2 == 1)
                {
                    Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                }
            }
        }
        yield return new WaitForSeconds(levelThirteenSpawnDelay);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
            Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
            Vector3 spawnLocation2 = new Vector3(
                spawnPoints[i].transform.position.x,
                spawnPoints[i].transform.position.y + 1,
                spawnPoints[i].transform.position.z
            );
            Instantiate(obstaclePrefab, spawnLocation2, Quaternion.identity);
        }
        yield return new WaitForSeconds(levelThirteenSpawnDelay);
        StartCoroutine(SpawnObstaclesLevelThirteen());
    }

    IEnumerator SpawnObstaclesLevelFourteen()
    {
        int spawn = Random.Range(0, 8);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != spawn && i != spawn + 1)
            {
                Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                Vector3 spawnLocation2 = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation2, Quaternion.identity);
            }
            else
            {
                int spawnNumber2 = Random.Range(0,2);
                if (spawnNumber2 == 0)
                {
                    Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                }
                if (spawnNumber2 == 1)
                {
                    Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                }
            }
        }
        yield return new WaitForSeconds(levelFourteenSpawnDelay);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
            Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
            Vector3 spawnLocation2 = new Vector3(
                spawnPoints[i].transform.position.x,
                spawnPoints[i].transform.position.y + 1,
                spawnPoints[i].transform.position.z
            );
            Instantiate(obstaclePrefab, spawnLocation2, Quaternion.identity);
        }
        yield return new WaitForSeconds(levelFourteenSpawnDelay);
        StartCoroutine(SpawnObstaclesLevelFourteen());
    }

    IEnumerator SpawnObstaclesLevelFifteen()
    {
        int spawn = Random.Range(0, 9);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != spawn)
            {
                Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                Vector3 spawnLocation2 = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation2, Quaternion.identity);
            }
            else
            {
                int spawnNumber2 = Random.Range(0,2);
                if (spawnNumber2 == 0)
                {
                    Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                }
                if (spawnNumber2 == 1)
                {
                    Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y + 1,
                    spawnPoints[i].transform.position.z
                );
                Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
                }
            }
        }
        yield return new WaitForSeconds(levelFifteenSpawnDelay);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Vector3 spawnLocation = new Vector3(
                    spawnPoints[i].transform.position.x,
                    spawnPoints[i].transform.position.y,
                    spawnPoints[i].transform.position.z
                );
            Instantiate(obstaclePrefab, spawnLocation, Quaternion.identity);
            Vector3 spawnLocation2 = new Vector3(
                spawnPoints[i].transform.position.x,
                spawnPoints[i].transform.position.y + 1,
                spawnPoints[i].transform.position.z
            );
            Instantiate(obstaclePrefab, spawnLocation2, Quaternion.identity);
        }
        yield return new WaitForSeconds(levelFifteenSpawnDelay);
        StartCoroutine(SpawnObstaclesLevelFifteen());
        
    }
}
