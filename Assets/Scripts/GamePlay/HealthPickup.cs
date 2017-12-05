using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

    Transform player;
    public float pickupDistance = 15;
    public float health = 10;
    public AnimationCurve heighCurve;
    public float heightScaling = 5;
    public float speed = 10;
    float distance;
    private float baseHeight;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        baseHeight = transform.position.y;

    }
	
	// Update is called once per frame
	void Update () {

        distance = Vector3.Distance(player.position, transform.position);

        if (distance < 1.5f)
        {
            player.GetComponent<PlayerHealth>().AddHealth(health);
            Destroy(this.gameObject);
        }

        if (distance < pickupDistance)
        {
            Vector3 pos = transform.position;
            Vector3 direction = player.position - pos;
            direction.y = 0;
            pos += direction * Time.deltaTime * speed;
            pos.y = baseHeight + heighCurve.Evaluate(1 - (distance / pickupDistance)) * heightScaling;
            transform.position = pos;

        }


    }
}
