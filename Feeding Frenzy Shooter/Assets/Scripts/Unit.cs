﻿using UnityEngine;

public class Unit : MonoBehaviour
{

    public bool collided;
    public Unit collidedEnemy;

    private void FixedUpdate()
    {
        CheckCollision();
    }

    public void CheckCollision()
    {
        if (collided && collidedEnemy &&
                    collidedEnemy.transform.localScale.x > transform.localScale.x)
        {
        }
        else if (collided && collidedEnemy
                && collidedEnemy.transform.localScale.x < transform.localScale.x)
        {
            IncreaseMass();
            collidedEnemy.DepleteMass();
        }
    }

    public void DepleteMass()
    {
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.95f, 0.95f, 0f));
        if (transform.localScale.x < 0.35f)
        {
            Destroy(this.gameObject);
        }
    }

    public void IncreaseMass()
    {
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.01f, 1.01f, 0f));
    }
}