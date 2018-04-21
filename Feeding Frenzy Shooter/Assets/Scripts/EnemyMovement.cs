using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;

    private void Start()
    {
        speed = Random.Range(0.5f, 12f);
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        speed = LevelManager.instance.camSize * 0.8f;
    }
}
