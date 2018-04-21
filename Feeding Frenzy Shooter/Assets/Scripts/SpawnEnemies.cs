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
        time = 0;
        float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0 - Screen.height, 0)).y, 
                Camera.main.ScreenToWorldPoint(new Vector2(Screen.height, Screen.height * 2)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(-Screen.width, 0)).x, 
            Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.width * 2)).x);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        GameObject enemyObject = Instantiate(enemy, spawnPosition, Quaternion.identity);
        enemyObject.transform.Rotate(0f, 0f, Random.Range(0f, 360f));
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}
