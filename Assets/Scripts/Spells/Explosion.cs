using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public int DamagePerParticle = 10;
    // When the particles hit an enemy
    void OnParticleCollision(GameObject other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.Damage(DamagePerParticle);
        }

    }
}
