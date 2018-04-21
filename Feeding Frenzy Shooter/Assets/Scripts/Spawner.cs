using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject[] spawnPoints;

    public float maxTime = 5;
    public float minTime = 2;

    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;

    public List<GameObject> NorthSpawns;
    public List<GameObject> EastSpawns;
    public List<GameObject> SouthSpawns;
    public List<GameObject> WestSpawns;

    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawn");
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            SpawnEnemy(spawnPoints[i]);
        }
    }

    void FixedUpdate()
    {

        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            for (int i = 0; i < 10; i++)
            {
                SpawnEnemy();
            }
            SetRandomTime();
        }

    }

    void SpawnEnemy(GameObject spawnPoint = null)
    {
        time = 0;
        if (spawnPoint == null)
        {
            int i = Random.Range(0, spawnPoints.Length);
            spawnPoint = spawnPoints[i];
        }

        Vector2 spawnPosition = new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y);
        GameObject enemyObject = Instantiate(enemy, spawnPosition, Quaternion.identity);
        enemyObject.transform.Rotate(0f, 0f, Random.Range(0f, 360f));
        float randScale = Random.Range(LevelManager.instance.player.transform.localScale.x * 0.5f, LevelManager.instance.player.transform.localScale.x * 3f);
        enemyObject.transform.localScale = new Vector3(randScale, randScale, 0f);

        Vector2 randPos = new Vector2(Random.Range(transform.position.x - 10, transform.position.x + 10), Random.Range(transform.position.y - 10, transform.position.y + 10));
        // get direction you want to point at
        Vector2 direction = (randPos - (Vector2)transform.position).normalized;
        // set vector of transform directly
        transform.up = direction;

        LevelManager.instance.enemies.Add(enemyObject.GetComponentInParent<Enemy>());
    }

    public void AdjustSpawnPositions(float camSize)
    {
        for (int i = 0; i < NorthSpawns.Count; i++)
        {
            if (i < 3)
            {
                NorthSpawns[i].transform.position = new Vector3(NorthSpawns[i].transform.position.x, camSize * 2 * 2, 0f);
            }
            else if (i >= 3 && i < 6)
            {
                NorthSpawns[i].transform.position = new Vector3(NorthSpawns[i].transform.position.x, camSize * 2 * 4, 0f);
            }
            else if (i >= 6 && i < 9)
            {
                NorthSpawns[i].transform.position = new Vector3(NorthSpawns[i].transform.position.x, camSize * 2 * 6, 0f);
            }
        }

        for (int i = 0; i < EastSpawns.Count; i++)
        {
            if (i < 3)
            {
                EastSpawns[i].transform.position = new Vector3(camSize * 2 * 2, EastSpawns[i].transform.position.y, 0f);
            }
            else if (i >= 3 && i < 6)
            {
                EastSpawns[i].transform.position = new Vector3(camSize * 2 * 4, EastSpawns[i].transform.position.y, 0f);
            }
            else if (i >= 6 && i < 9)
            {
                EastSpawns[i].transform.position = new Vector3(camSize * 2 * 6, EastSpawns[i].transform.position.y, 0f);
            }
        }

        for (int i = 0; i < SouthSpawns.Count; i++)
        {
            if (i < 3)
            {
                SouthSpawns[i].transform.position = new Vector3(SouthSpawns[i].transform.position.x, camSize * 2 * 2, 0f);
            }
            else if (i >= 3 && i < 6)
            {
                SouthSpawns[i].transform.position = new Vector3(SouthSpawns[i].transform.position.x, camSize * 2 * 4, 0f);
            }
            else if (i >= 6 && i < 9)
            {
                SouthSpawns[i].transform.position = new Vector3(SouthSpawns[i].transform.position.x, camSize * 2 * 6, 0f);
            }
        }

        for (int i = 0; i < WestSpawns.Count; i++)
        {
            if (i < 3)
            {
                WestSpawns[i].transform.position = new Vector3(camSize * 2 * 2, WestSpawns[i].transform.position.y, 0f);
            }
            else if (i >= 3 && i < 6)
            {
                WestSpawns[i].transform.position = new Vector3(camSize * 2 * 4, WestSpawns[i].transform.position.y, 0f);
            }
            else if (i >= 6 && i < 9)
            {
                WestSpawns[i].transform.position = new Vector3(camSize * 2 * 6, WestSpawns[i].transform.position.y, 0f);
            }
        }
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}