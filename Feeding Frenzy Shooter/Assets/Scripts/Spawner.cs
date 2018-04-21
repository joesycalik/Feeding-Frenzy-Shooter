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
            SpawnEnemy();
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
        float randScale = Random.Range(0.4f, 5f);
        enemyObject.transform.localScale = new Vector3(randScale, randScale, 0f);

        Vector2 randPos = new Vector2(Random.Range(transform.position.x - 10, transform.position.x + 10), Random.Range(transform.position.y - 10, transform.position.y + 10));
        // get direction you want to point at
        Vector2 direction = (randPos - (Vector2)transform.position).normalized;
        // set vector of transform directly
        transform.up = direction;
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}