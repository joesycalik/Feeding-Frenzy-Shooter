using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bullet;
    public Vector3 bulletScale;
    public float speed;

    void Start()
    {
        bullet.GetComponent<Bullet>().speed = speed;
        bulletScale = bullet.transform.localScale;
    }

    public void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.transform.localScale = bulletScale;
    }

    public void IncreaseBulletScale()
    {
        bulletScale = Vector3.Scale(LevelManager.instance.player.transform.localScale, new Vector3(0.75f, 0.75f, 0f));
        speed = LevelManager.instance.player.playerMovement.speed * 3;
    }

    public void DecreaseBulletScale()
    {
        bulletScale = Vector3.Scale(LevelManager.instance.player.transform.localScale, new Vector3(0.75f, 0.75f, 0f));
        speed = LevelManager.instance.player.playerMovement.speed * 3;
    }
}
