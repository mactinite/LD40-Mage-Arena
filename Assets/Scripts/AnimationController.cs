﻿using CustomInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    FirstPersonDrifter controller;
    private ParticleSystem.EmissionModule emission;
    public Animator anim;
    public PlayerInput playerInput;
    public SpellController spellController;
    bool castButton = false;

    // Use this for initialization
    void Start () {
        controller = GetComponent<FirstPersonDrifter>();
        spellController = GetComponent<SpellController>();
        playerInput = GetComponent<PlayerInput>();
    }
	
	// Update is called once per frame
	void Update () {
        bool sprint = playerInput.GetButtonInput(PlayerInput.SPRINT_BUTTON);
        bool isCasting = spellController.isCasting;
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

        

        if (!sprint && !castButton && !isCasting)
        {
            if (playerInput.GetButtonInput(PlayerInput.CAST_BUTTON_DOWN))
            {
                castButton = true;
                anim.SetTrigger("CastStart");
                if (!spellController.currentSpell.IsLooping())
                {
                    anim.SetTrigger("CastEnd");
                }
            }


        }
        if (playerInput.GetButtonInput(PlayerInput.CAST_BUTTON_UP))
        {
            if (castButton)
            {
                castButton = false;
                if (spellController.currentSpell.IsLooping())
                {
                    anim.SetTrigger("CastEnd");
                }
            }
        }


    }
}