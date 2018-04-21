using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Gun gun;
    float shootDelay;
    bool minMass;
    bool collided;
    Enemy collidedEnemy;

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && !minMass && shootDelay == 0)
        {
            gun.Shoot();
            shootDelay = 0.3f;
            DepleteMass();
        }
        if (shootDelay > 0)
        {
            shootDelay -= 0.1f;
            if (shootDelay < 0)
            {
                shootDelay = 0;
            }
        }

        if (collided)
        {
            IncreaseMass();
            collidedEnemy.DepleteMass();
        }
    }

    private void DepleteMass()
    {
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.99f, 0.99f, 0.99f));
        if (transform.localScale.x < 0.5f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            minMass = true;
        }
    }

    private void IncreaseMass()
    {
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.01f, 1.01f, 0f));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == "Enemy")
        {
            collided = true;
            collidedEnemy = col.GetComponentInParent<Enemy>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collided = false;
        collidedEnemy = null;
    }
}