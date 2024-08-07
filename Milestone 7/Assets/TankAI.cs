using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    Animator anim;
    public GameObject player;

    public GameObject bullet;
    public GameObject turret;

    public string waypointTag;

    private bool isPlayerAlive = true;

    public GameObject GetPlayer()
    {
        return player;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();

        if (player == null)
        {
            isPlayerAlive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            isPlayerAlive = false;
            StopFiring();
        }
        else
        {
            anim.SetFloat("distance", Vector3.Distance(this.transform.position, player.transform.position));
        }
    }

    void Fire()
    {
        if (isPlayerAlive)
        {
            GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
            b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
        }
    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }

    public void StartFiring()
    {
        if (isPlayerAlive)
        {
            InvokeRepeating("Fire", 0.5f, 0.5f);
        }
    }
}