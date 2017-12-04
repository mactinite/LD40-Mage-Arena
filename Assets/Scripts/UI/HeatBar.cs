using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatBar : MonoBehaviour {

    SpellController spellController;
    Image heatBarImage;
    public Transform HeatWarning;
    void Start()
    {
        spellController = GameObject.FindGameObjectWithTag("Player").GetComponent<SpellController>();
        heatBarImage = GetComponentsInChildren<Image>()[1];
        
        spellController.OnHeatChange = OnHeatChange;
    }

    public void OnHeatChange(float newHeat)
    {
        heatBarImage.fillAmount = newHeat / spellController.maxHeat;
        if(newHeat / spellController.maxHeat >= 0.75f)
        {
            HeatWarning.gameObject.SetActive(true);
        }
        else
        {
            HeatWarning.gameObject.SetActive(false);
        }
        heatBarImage.SetAllDirty();
    }

}
