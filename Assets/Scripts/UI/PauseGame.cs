using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CustomInput;
public class PauseGame : MonoBehaviour {

    public GameObject pauseMenu;
    public PlayerInput playerInput;
    public SimpleSmoothMouseLook mouselook;
    public Slider sensitivitySlider;
    public SpellController spellController;

    bool isPaused;

    public void SetSensitivity()
    {
        mouselook.sensitivity = new Vector2(sensitivitySlider.value,sensitivitySlider.value);
    }
    public void Resume()
    {
        TogglePause();
    }
    public void ExitGame()
    {
        Application.Quit();
    }


    // Update is called once per frame
    void Update () {
        if (playerInput.GetButtonInput(PlayerInput.PAUSE_BUTTON))
        {
            TogglePause();
        }
	}


    void TogglePause()
    {
        pauseMenu.SetActive(isPaused = !isPaused);
        Time.timeScale = isPaused ? 0 : 1;
        mouselook.enabled = !isPaused;
        spellController.enabled = !isPaused;
    }

    void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
