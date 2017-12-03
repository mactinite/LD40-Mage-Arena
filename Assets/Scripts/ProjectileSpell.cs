using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : MonoBehaviour, ISpell {


    public Projectile projectilePrefab;
    public float delay = 0.25f;
    bool fired = false;
    private Projectile primedProjectile;
    // This is pretty cool, actions are dope
    public void Cast(SpellController controller)
    {
        fired = false;

        Vector3 direction = controller.targetedPoint - transform.position;
        direction.Normalize();
        primedProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.LookRotation(direction));

        StartCoroutine(DelaySpell(delay, 
        () =>{
            direction = controller.targetedPoint - transform.position;
            direction.Normalize();
            fired = true;
            primedProjectile.Fire(direction);
        }));
    }

    IEnumerator DelaySpell(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action();
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
        return false;
    }

    void Update()
    {
        if (!fired && primedProjectile != null)
        {
            primedProjectile.transform.position = transform.position;
        }
    }


    public void Stop(SpellController controller)
    {
        // Not called for non-looping spells;
    }

}
