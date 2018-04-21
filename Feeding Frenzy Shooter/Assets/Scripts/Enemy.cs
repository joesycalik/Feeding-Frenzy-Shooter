using UnityEngine;

public class Enemy : Unit {

    void OnTriggerEnter2D(Collider2D col)
    {
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == "Enemy")
        {
            collided = true;
            collidedEnemy = col.GetComponentInParent<Enemy>();
        }
        else if (col.gameObject.tag == "Playter")
        {
            collided = true;
            collidedEnemy = col.GetComponentInParent<Player>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collided = false;
        collidedEnemy = null;
    }
}
