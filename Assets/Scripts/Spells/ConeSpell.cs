using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeSpell : MonoBehaviour, ISpell {

    public ParticleSystem effect;
    public int DamagePerParticle = 5;
    public bool isLoop = true;
    public float heatPerSecond = 25;


    public void Cast(SpellController controller)
    {
        effect.Play();
    }

    public void Equip(SpellController controller)
    {
        gameObject.SetActive(true);
    }

    public void UnEquip(SpellController controller)
    {
        gameObject.SetActive(false);
    }

    public bool IsLooping()
    {
        return isLoop;
    }

    public void Stop(SpellController controller)
    {
        effect.Stop();
    }


    // When the particles hit an enemy
    void OnParticleCollision(GameObject other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if(damageable != null)
        {
            damageable.Damage(DamagePerParticle);
        }

    }

    public string GetName()
    {
        return gameObject.name;
    }

    public float GetHeat()
    {
        return heatPerSecond;
    }
}
