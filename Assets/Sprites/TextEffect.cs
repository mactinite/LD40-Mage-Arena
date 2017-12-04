using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Outline))]
public class TextEffect : MonoBehaviour {

    public float effectSpeed = 0.25f;
    private Outline outline;
	// Update is called once per frame
	void Update () {
		if(outline == null)
        {
            outline = GetComponent<Outline>();
        }
        Vector2 dist = outline.effectDistance;
        dist.x += effectSpeed * Time.deltaTime;
        outline.effectDistance = dist;

    }
}
