using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public GameObject explosion;
    public int playerDamage = 5;
    public int enemyDamage = 10;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            EnemyHP enemyHP = col.gameObject.GetComponent<EnemyHP>();
            if (enemyHP != null)
            {
                enemyHP.TakeDamage(playerDamage);
            }
        }
        else if (col.gameObject.CompareTag("Player"))
        {
            PlayerHP playerHP = col.gameObject.GetComponent<PlayerHP>();
            if (playerHP != null)
            {
                playerHP.TakeDamage(enemyDamage);
            }
        }

        GameObject e = Instantiate(explosion, this.transform.position, Quaternion.identity);
    	Destroy(e,1.5f);
    	Destroy(this.gameObject);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
