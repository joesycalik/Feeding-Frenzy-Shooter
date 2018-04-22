using UnityEngine;
using System.Collections;

public class Player : Unit
{
    public Gun gun;
    float shootDelay;
    public int hits;
    float minMass = 0.35f;
    public PlayerMovement playerMovement;

    private void Start()
    {
        hits = 0;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && shootDelay == 0)
        {
            gun.Shoot();
            shootDelay = 0.3f;
            DepleteMass(false);
        }
        if (shootDelay > 0)
        {
            shootDelay -= 0.1f;
            if (shootDelay < 0)
            {
                shootDelay = 0;
            }
        }

        CheckCollision();
    }

    
   public void DepleteMass(bool hit = true)
    {
        if (transform.localScale.x < minMass)
        {
            Destroy(this);
        }
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.99f, 0.99f, 0.97f));
        playerMovement.speed *= 0.99f;
        gun.DecreaseBulletScale();
        LevelManager.instance.score -= 1;
    }
    
    override
    public void IncreaseMass()
    {
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.01f, 1.01f, 0f));
        playerMovement.speed *= 1.01f;
        gun.IncreaseBulletScale();
        LevelManager.instance.score += 1;
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