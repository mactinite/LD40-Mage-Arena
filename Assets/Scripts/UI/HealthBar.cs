using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    PlayerHealth playerHealth;
    Image healthBarImage;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        healthBarImage = GetComponentsInChildren<Image>()[1];

        playerHealth.OnHealthChanged = OnHealthChanged;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnHealthChanged(float newHealth)
    {
        healthBarImage.fillAmount = newHealth / playerHealth.GetMaxHealth();
        healthBarImage.SetVerticesDirty();
    }
}
