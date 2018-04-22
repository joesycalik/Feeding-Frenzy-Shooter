using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    Camera cam;
    public float minSize;
    Spawner spawner;
    float camIncreaseThreshold;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        cam = GetComponentInParent<Camera>();
        spawner = GetComponentInChildren<Spawner>();
        camIncreaseThreshold = LevelManager.instance.player.originalScale;
        LevelManager.instance.camSize = cam.orthographicSize;
        spawner.AdjustSpawnPositions(cam.orthographicSize);
    }

    private void LateUpdate()
    {
        //if (LevelManager.instance.player.transform.localScale.x >= camIncreaseThreshold)
        //{
        //    camIncreaseThreshold = LevelManager.instance.player.transform.localScale.x;
        //    LevelManager.instance.camSize = cam.orthographicSize;
        //    spawner.AdjustSpawnPositions(cam.orthographicSize);
        //}
    }
}