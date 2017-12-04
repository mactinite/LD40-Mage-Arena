using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrentSpellText : MonoBehaviour {

    private Text spellDisplay;
    private SpellController spellController;
    void Start()
    {
        spellController = GameObject.FindGameObjectWithTag("Player").GetComponent<SpellController>();
        spellDisplay = GetComponent<Text>();
        spellDisplay.text = spellController.currentSpell.GetName();
    }
    private void Update()
    {
        spellDisplay.text = spellController.currentSpell.GetName();
    }

}
