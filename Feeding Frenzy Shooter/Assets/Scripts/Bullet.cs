using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = transform.TransformDirection(Vector2.up * speed);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
