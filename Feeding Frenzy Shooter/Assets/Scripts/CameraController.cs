using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    Camera cam;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        cam = GetComponentInParent<Camera>();
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }

    public void IncreaseSize()
    {
        cam.orthographicSize = cam.orthographicSize * 1.01f;
    }

    public void DecreaseSize()
    {
        cam.orthographicSize = cam.orthographicSize * 0.99f;
    }
}