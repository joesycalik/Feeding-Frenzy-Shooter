using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    Camera cam;
    public float minSize;
    Spawner spawner;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        cam = GetComponentInParent<Camera>();
        spawner = GetComponentInChildren<Spawner>();
    }

    // LateUpdate is called after Update each frame
    void Update()
    {
        if (player)
        {
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            transform.position = player.transform.position + offset;
            cam.orthographicSize = player.transform.localScale.x * 7.5f;
            LevelManager.instance.camSize = cam.orthographicSize;
            spawner.AdjustSpawnPositions(cam.orthographicSize);
        }
        else
        {
            GameManager.instance.score = LevelManager.instance.score;
            SceneManager.LoadScene("EndScreen");
        }
        
    }
}