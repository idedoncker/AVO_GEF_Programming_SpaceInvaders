using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletOrigin;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // left-mouse click
        {
            Instantiate(bullet, bulletOrigin.position, Quaternion.identity);
        }
    }
}
