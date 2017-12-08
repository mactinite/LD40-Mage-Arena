using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public int DamagePerParticle = 10;
    public bool isEnemy = false;
    // When the particles hit an enemy
    void OnParticleCollision(GameObject other)
    {

        if (isEnemy)
        {
            PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.Damage(DamagePerParticle);
            }
        }
        else
        {
            IDamageable damageable = other.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.Damage(DamagePerParticle);
            }
        }
    }
}
