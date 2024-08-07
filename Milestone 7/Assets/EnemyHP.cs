using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private Animator anim;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy took damage: " + damage + ", Current Health: " + currentHealth);

        if (anim != null)
        {
            anim.SetFloat("hp", (float)currentHealth / maxHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
