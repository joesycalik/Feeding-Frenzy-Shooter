using UnityEngine;

public class Enemy : Unit
{

    void OnTriggerEnter2D(Collider2D col)
    {
        //all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
        if (col.gameObject.tag == "Enemy")
        {
            collided = true;
            collidedEnemy = col.GetComponentInParent<Enemy>();
        }
        else if (col.gameObject.tag == "Player")
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

    public new void DepleteMass()
    {
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.90f, 0.90f, 0f));
        if (transform.localScale.x < 0.35f)
        {
            Kill();
        }
    }

    public void Kill()
    {
        LevelManager.instance.enemies.Remove(this);
        Destroy(this.gameObject);
    }
}