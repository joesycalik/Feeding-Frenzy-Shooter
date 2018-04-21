using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bullet;
    public float speed;

    void Start()
    {
        bullet.GetComponent<Bullet>().speed = speed;
    }

    public void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
