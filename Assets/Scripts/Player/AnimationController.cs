using CustomInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    FirstPersonDrifter controller;
    public Animator anim;
    public PlayerInput playerInput;
    public SpellController spellController;
    bool castButton = false;
    bool ventButton = false;
    public ParticleSystem ventFX;

    // Use this for initialization
    void Start () {
        controller = GetComponent<FirstPersonDrifter>();
        spellController = GetComponent<SpellController>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        bool sprint = playerInput.GetButtonInput(PlayerInput.SPRINT_BUTTON);
        bool isCasting = spellController.isCasting;
        bool isVenting = spellController.isVenting;
        if (playerInput.GetAxisInput(PlayerInput.MOVE_X) != 0 || playerInput.GetAxisInput(PlayerInput.MOVE_Y) != 0)
        {
            anim.SetBool("isMoving", true);
            anim.SetBool("isRunning", sprint);
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isMoving", false);
        }

        anim.SetBool("isSpellOneShot", !spellController.currentSpell.IsLooping());



        if (!sprint && !isCasting && !isVenting)
        {
            if (playerInput.GetButtonInput(PlayerInput.CAST_BUTTON_DOWN))
            {
                castButton = true;
                anim.SetTrigger("CastStart");
                anim.ResetTrigger("CastEnd");
            }
        }
        if (playerInput.GetButtonInput(PlayerInput.CAST_BUTTON_UP))
        {
            castButton = false;
            if (isCasting)
            {
                if (spellController.currentSpell.IsLooping())
                {
                    anim.ResetTrigger("CastStart");
                    anim.SetTrigger("CastEnd");
                }
            }
        }

        if (!isVenting && !sprint && !isCasting)
        {
            if (playerInput.GetButtonInput(PlayerInput.VENT_BUTTON_DOWN))
            {
                ventButton = true;
                ventFX.Play();
                if (spellController.currentSpell.IsLooping())
                {
                    anim.SetTrigger("CastEnd");
                }
                anim.SetTrigger("VentStart");
            }
        }
        if (isVenting)
        {
            if (playerInput.GetButtonInput(PlayerInput.VENT_BUTTON_UP))
            {
                ventFX.Stop();
                ventButton = false;
                anim.SetTrigger("VentEnd");
            }
        }
    }
}
