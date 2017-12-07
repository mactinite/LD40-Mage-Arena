using CustomInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    FirstPersonDrifter controller;
    public Animator anim;
    public PlayerInput playerInput;
    public SpellController spellController;
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
        bool isSprinting = controller.enableRunning && playerInput.GetButtonInput(PlayerInput.SPRINT_BUTTON);
        bool isCasting = spellController.isCasting;
        bool isVenting = spellController.isVenting;
        anim.SetBool("isSpellOneShot", !spellController.currentSpell.IsLooping());

        if (playerInput.GetAxisInput(PlayerInput.MOVE_X) != 0 || playerInput.GetAxisInput(PlayerInput.MOVE_Y) != 0) //TODO: Move this to a flag on the character controller
        {
            anim.SetBool("isMoving", true);
            anim.SetBool("isRunning", isSprinting);
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isMoving", false);
        }

        anim.SetBool("Casting", isCasting);

        if (isVenting)
        {
            ventFX.Play();
            anim.SetBool("Venting", true);
        }
        else
        {
            ventFX.Stop();
            anim.SetBool("Venting", false);
        }
    }
}
