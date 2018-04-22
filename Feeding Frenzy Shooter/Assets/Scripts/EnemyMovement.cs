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

        checkWrapMovement();
    }

    void checkWrapMovement()
    {
        if (transform.position.y > LevelManager.instance.camSize * 2)
        {
            transform.position = new Vector2(transform.position.x, -LevelManager.instance.camSize * 2);
        }
        else if (transform.position.y < -LevelManager.instance.camSize * 2)
        {
            transform.position = new Vector2(transform.position.x, LevelManager.instance.camSize * 2);
        }

        if (transform.position.x > LevelManager.instance.camSize * 2)
        {
            transform.position = new Vector2(-LevelManager.instance.camSize * 2, -transform.position.y);
        }
        else if (transform.position.x < -LevelManager.instance.camSize * 2)
        {
            transform.position = new Vector2(LevelManager.instance.camSize * 2, transform.position.y);
        }
    }
}
