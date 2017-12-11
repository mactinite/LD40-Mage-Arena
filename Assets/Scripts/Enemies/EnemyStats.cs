using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour, IDamageable
{
    public int health = 300;
    private int maxHealth;
    public Transform drop;
    public Transform DeathFX;

    public void Damage(int damage)
    {
        DamageDisplayManager.instance.SpawnText(damage.ToString(), Color.red, this.transform);
        if (health - damage <= 0)
        {
            Die();
        }
        else
        {
            health -= damage;
        }
    }

    void Die()
    {
        if (drop != null)
        {
            Instantiate(drop, transform.position, Quaternion.identity);
        }
        if (DeathFX != null)
        {
            Instantiate(DeathFX, transform.position, Quaternion.identity);
        }
        GameManager.instance.EnemyDied(this.gameObject);
        Destroy(this.gameObject);
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

}
