using UnityEngine;
using System.Collections;

public class Player : Unit
{
    public Gun gun;
    float shootDelay;
    public int hits;
    public float originalScale;
    public PlayerMovement playerMovement;

    private void Start()
    {
        hits = 0;
        originalScale = transform.localScale.x;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            gun.Shoot();
            shootDelay = 0.3f;
            DepleteMass(true);
        }

        CheckCollision();
    }

    override
   public void DepleteMass()
    {
        if (transform.localScale.x < originalScale / 2)
        {
            Destroy(this.gameObject);
        }
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.90f, 0.90f, 0f));
        playerMovement.speed *= 1.001f;
        gun.DecreaseBulletScale();
    }

    public void DepleteMass(bool shoot)
    {
        if (transform.localScale.x < originalScale / 2)
        {
            Destroy(this.gameObject);
        }
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.9995f, 0.9995f, 0));
        playerMovement.speed *= 1.001f;
        gun.DecreaseBulletScale();
    }

    override
    public void IncreaseMass()
    {
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.015f, 1.015f, 0f));
        playerMovement.speed *= 0.995f;
        gun.IncreaseBulletScale();
        LevelManager.instance.score += 2;
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