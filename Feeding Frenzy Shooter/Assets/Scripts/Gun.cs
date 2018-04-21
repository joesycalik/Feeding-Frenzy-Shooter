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
        bulletScale = Vector3.Scale(bulletScale, new Vector3(1.01f, 1.01f, 0f));
    }

    public void DecreaseBulletScale()
    {
        bulletScale = Vector3.Scale(bulletScale, new Vector3(0.99f, 0.99f, 0f));
    }
}
