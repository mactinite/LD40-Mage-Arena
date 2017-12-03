using CustomInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour {

    public Transform spellContainer;
    public List<ISpell> acquiredSpells = new List<ISpell>();
    public ISpell currentSpell;
    private int spellIndex = 0;
    private PlayerInput playerInput;
    private FirstPersonDrifter fpsController;

    public Vector3 targetedPoint;
    private Vector3 centerScreen;
    public float recoveryTime = 0.5f;
    private float recoveryTimer;
    private float switchBuffer = 0.25f;
    private float switchTimer;
    private bool isSwitching = false;
    public bool isCasting = false;
    // init
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        fpsController = GetComponent<FirstPersonDrifter>();
        foreach(Transform child in spellContainer)
        {
            ISpell spell = child.GetComponent<ISpell>();
            // Ignore transforms that don't have spells on them, but we will warn
            if (spell != null)
            {
                acquiredSpells.Add(child.GetComponent<ISpell>());
                child.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning(child.name + " has no spell attached!");
            }

            
        }
        
        currentSpell = acquiredSpells[0];
        currentSpell.Equip(this);
    }

    // Update is called once per frame
    void Update () {
        centerScreen = new Vector3(Screen.height / 2, Screen.width / 2, 0);
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100)){
            targetedPoint = hit.point;
        }
        else
        {
            targetedPoint = ray.GetPoint(100);
        }

        Debug.DrawLine(ray.origin, targetedPoint);

        if (playerInput.GetButtonInput(PlayerInput.SWITCH_SPELL_FORWARD) && !isSwitching)
        {
            CycleSpellForward();
        }

        if (playerInput.GetButtonInput(PlayerInput.SWITCH_SPELL_BACK) && !isSwitching)
        {
            CycleSpellBackward();
        }

        if (currentSpell.IsLooping())
        {
            
            if (playerInput.GetButtonInput(PlayerInput.CAST_BUTTON_DOWN) && !playerInput.GetButtonInput(PlayerInput.SPRINT_BUTTON))
            {
                currentSpell.Cast(this);
                fpsController.enableRunning = false;
                isCasting = true;
            }

            if (playerInput.GetButtonInput(PlayerInput.CAST_BUTTON_UP))
            {
                currentSpell.Stop(this);
                fpsController.enableRunning = false;
                isCasting = false;
            }
        }
        else
        {
            if (playerInput.GetButtonInput(PlayerInput.CAST_BUTTON_DOWN) && !playerInput.GetButtonInput(PlayerInput.SPRINT_BUTTON) && isCasting != true)
            {
                currentSpell.Cast(this);
                isCasting = true;
            }
        }

        if (!currentSpell.IsLooping() && isCasting)
        {
            recoveryTimer += Time.deltaTime;
            if(recoveryTimer >= recoveryTime)
            {
                isCasting = false;
                recoveryTimer = 0;
            }
        }

        if (isSwitching)
        {
            switchTimer += Time.deltaTime;
            if (switchTimer >= switchBuffer)
            {
                isSwitching = false;
                switchTimer = 0;
            }
        }

        		
	}

    void CycleSpellForward()
    {
        if (!isCasting && !isSwitching)
        {
            isSwitching = true;
            currentSpell.UnEquip(this);
            int currentIndex = acquiredSpells.IndexOf(currentSpell);
            if (currentIndex == acquiredSpells.Count - 1)
            {
                spellIndex = 0;
                currentSpell = acquiredSpells[0];
            }
            else
            {
                spellIndex++;
                currentSpell = acquiredSpells[spellIndex];
            }
            currentSpell.Equip(this);
        }          
    }

    void CycleSpellBackward()
    {
        if (!isCasting && !isSwitching)
        {
            isSwitching = true;
            currentSpell.UnEquip(this);
            int currentIndex = acquiredSpells.IndexOf(currentSpell);
            if (currentIndex == 0)
            {
                spellIndex = acquiredSpells.Count - 1;
                currentSpell = acquiredSpells[acquiredSpells.Count - 1];
            }
            else
            {
                spellIndex--;
                currentSpell = acquiredSpells[spellIndex];
            }
            currentSpell.Equip(this);

        }
    }
}
