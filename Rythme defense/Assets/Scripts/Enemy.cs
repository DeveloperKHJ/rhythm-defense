using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;
    public float startHealth = 100;
    private float currentHealth;
    public float gold = 10f;
    private bool isDead = false;
    //public GameObject deathEffect;

    //[Header("Unity Stuff")]
    //public Image healthBar;

    void Start()
    {
        currentHealth = startHealth;
        speed = startSpeed;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        //healthBar.fillAmount = currentHealth / startHealth;

        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    // Apply slow to enemy with Laser beam
    public void Slow(float slowRate)
    {
        speed = startSpeed * (1f - slowRate);
    }

    private void Die()
    {
        isDead = true;
        //PlayerStats.Money += (int)gold;

        //GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 3f);

        WaveSpawner.enemiesAlive--;

        Destroy(gameObject);

    }
    
}


