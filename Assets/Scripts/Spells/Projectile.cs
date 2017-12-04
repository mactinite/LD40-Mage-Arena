using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {


    private Rigidbody rb;
    public int damage = 50;
    public float speed = 20;
    public Transform hitFX;

	void Awake () {
        rb = GetComponent<Rigidbody>();
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.Damage(damage);
        }

        if (hitFX != null)
        {
            Instantiate(hitFX, transform.position, Quaternion.identity);
        }

        Destroy(this.gameObject);
        
    }

    public void Fire(Vector3 direction)
    {
        rb.AddForce(direction * speed, ForceMode.Force);
        GetComponent<Collider>().enabled = true;
    }
}
