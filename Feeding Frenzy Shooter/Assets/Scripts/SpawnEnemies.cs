using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public GameObject enemy;
    Vector3 spawnPoint;

    public float maxTime = 5;
    public float minTime = 2;

    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;

    void Start()
    {
        for (int i = 0; i < 25; i++)
        {
            SpawnEnemy();
        }
    }

    void FixedUpdate()
    {

        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            for (int i = 0; i < 5; i++)
            {
                SpawnEnemy();
            }
            SetRandomTime();
        }

    }

    void SpawnEnemy()
    {
        float screenOffset = 10;
        time = 0;
        float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0 - Screen.height * screenOffset, 0)).y, 
                Camera.main.ScreenToWorldPoint(new Vector2(Screen.height * screenOffset, Screen.height * screenOffset)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(-Screen.width * screenOffset, 0)).x, 
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * screenOffset, Screen.width * screenOffset)).x);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        GameObject enemyObject = Instantiate(enemy, spawnPosition, Quaternion.identity);
        enemyObject.transform.Rotate(0f, 0f, Random.Range(0f, 360f));

        float randomScale = Random.Range(0.7f, 5f);
        enemyObject.transform.localScale = new Vector3(randomScale, randomScale, 0f);
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}
