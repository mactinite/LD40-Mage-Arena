using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFadeAway : MonoBehaviour {
    public float lifeTime = 1f;
    public AnimationCurve curve;
    private CanvasRenderer canvasRender;
    private float timer = 0;

    private void Start()
    {
        canvasRender = GetComponent<CanvasRenderer>();
        canvasRender.SetAlpha(curve.Evaluate((timer / lifeTime)));
    }

    public void SetTime(float time)
    {
        lifeTime = time;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        canvasRender.SetAlpha(curve.Evaluate((timer / lifeTime)));
        if(timer > lifeTime)
        {
            Destroy(this.gameObject);
        }
    }

}
