using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject turret;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
    }
}