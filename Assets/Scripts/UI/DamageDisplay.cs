using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageDisplay : MonoBehaviour {
    public float riseSpeed = 0.25f;
    public float fadeTime = 0.5f;
    public Transform riseFrom;
    private Vector3 origin;
    public float height;
    private Text uiText;

    private float alpha;
    private float currentHeight = 0;
    private float xOffset = 0;
    private float timer;
    public bool started;

    private void OnEnable()
    {
        
        
    }

    public void Init()
    {
        xOffset = Random.Range(-10f, 10f);
        uiText = GetComponent<Text>();
        origin = riseFrom.position;
        alpha = 1;
        currentHeight = transform.position.y;
        timer = 0;
    }

    private void Update()
    {
        if (started)
        {
            StartOnTransform(riseFrom);
            UpdatePosition();
            UpdateAlpha();
        }
    }


    public void SetText(string text, Color color)
    {
        uiText.text = text;
        uiText.color = color;
    }


    public void UpdatePosition()
    {
        currentHeight += riseSpeed * Time.deltaTime;
    }

    public void UpdateAlpha()
    {
        timer += Time.deltaTime;
        if(timer < fadeTime)
        {
            Color color = uiText.color;
            alpha = 1 - (timer/fadeTime);
            color.a = alpha;
            uiText.color = color;
        }
        else
        {
            ObjectPool.Recycle(this.gameObject);
        }
    }

    public void StartOnTransform(Transform transform)
    {
        RectTransform UI_Element = this.GetComponent<RectTransform>();
        RectTransform CanvasRect = uiText.canvas.GetComponentInChildren<RectTransform>();
        

        Vector3 ViewportPosition = Camera.main.WorldToViewportPoint(origin + Vector3.up * currentHeight);
        if (ViewportPosition.z > 0)
        {
            uiText.enabled = true;
            Vector2 WorldObject_ScreenPosition = new Vector2(
            ((ViewportPosition.x  * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
            ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));
            //now you can set the position of the ui element
            WorldObject_ScreenPosition.x += xOffset;
            UI_Element.anchoredPosition = WorldObject_ScreenPosition;
        }
        else
        {
            ObjectPool.Recycle(this.gameObject);
            uiText.enabled = false;
        }



    }


}
