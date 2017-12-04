using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health = 100;
    private float maxHealth;

    public delegate void UpdateUI(float newHealth);
    public UpdateUI OnHealthChanged = delegate { };

    private void Start()
    {
        maxHealth = health;
    }

    public void Damage(float damage)
    {
        if (health - damage <= 0)
        {
            health = 0;
            Die();
        }
        else
        {
            health -= damage;
        }
        OnHealthChanged(health);
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void Die()
    {
        Debug.Log("Player Dead");
    }
    
}
