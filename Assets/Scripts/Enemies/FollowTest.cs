using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTest : MonoBehaviour, IDamageable {

    public GameObject target;
    private NavMeshAgent agent;

    public int health = 300;
    int maxHealth;
    public void Damage(int damage)
    {
        if(health - damage <= 0)
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
        Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        maxHealth = health;

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(target.transform.position);
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
