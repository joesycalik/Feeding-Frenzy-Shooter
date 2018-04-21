using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Gun gun;
    float shootDelay;
    bool minMass;

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
}