using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float health = 100;
    private float maxHealth;

    public ParticleSystem healthAddFX;
    public ParticleSystem healthHitFX;
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
        healthHitFX.Emit(Mathf.CeilToInt(damage));
    }

    public void AddHealth(float pickedUp)
    {
        Debug.Log("Add " + pickedUp + " health");
        if (health < maxHealth)
        {
            healthAddFX.Emit((int)pickedUp);
            OnHealthChanged(health);

            if (health + pickedUp < maxHealth)
            {
                health += pickedUp;
            }
            else
            {
                health = maxHealth;
            }

        }

        
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
        GameManager.instance.OnPlayerDead();
        Debug.Log("Player Dead");
    }
    
}
