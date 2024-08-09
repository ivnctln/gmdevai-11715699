using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdPanic : MonoBehaviour
{
    GameObject player;
    GameObject[] agents;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agents = GameObject.FindGameObjectsWithTag("AI");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            foreach (GameObject a in agents)
            {
                a.GetComponent<AIControl>().DetectPlayer(player.transform.position);
            }
        }
    }
}
