using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;

    private void Start()
    {
        speed = Random.Range(0.5f, 3.5f);
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
