using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public Transform textPrefab;
    public Transform textParent;

    public int CurrentWave = 1;
    public int maxWaves = 50;
    public AnimationCurve difficultyCurve;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
        StartCoroutine(IntroSequence());
    }


    IEnumerator WaveAnnounce(int wave)
    {
        ShowText("Wave " + wave, 4.9f);
        yield return new WaitForSeconds(5f);
    }

    IEnumerator IntroSequence()
    {

        Debug.Log("IntroSequence");
        // Delay with no text, let the player check out their surroundings.
        yield return new WaitForSeconds(3f);
        // Welcome to the Arena, Mage.
        ShowText("Welcome to the Arena, Mage.", 4.9f);
        yield return new WaitForSeconds(5f);
        // We are going to test your self control
        ShowText("We are going to test your self control.", 4.9f);
        yield return new WaitForSeconds(5f);
        //Ignis...
        ShowText("Ignis...", 2.4f);
        yield return new WaitForSeconds(2.5f);
        // Fire....
        ShowText("Fire...", 2.4f);
        yield return new WaitForSeconds(2.5f);
        // Here you must protect yourself with the fire that burns inside you.
        ShowText("Here you must protect yourself with the fire that burns inside you.", 5.9f);
        yield return new WaitForSeconds(6f);
        // Show prompts for casting spell
        ShowText("Cast spells with [Left Click] or [Right Bumper]", 5.9f);
        yield return new WaitForSeconds(6.0f);
        // Be wary, mage, for if you indulge too much you will hurt yourself.
        ShowText("Be wary, mage, for if you indulge too much you will hurt yourself.", 7.9f);
        yield return new WaitForSeconds(8.0f);
        // You must cool yourself off if you wish to remain unharmed.
        ShowText("You must cool yourself off if you wish to remain unharmed.", 4.9f);
        yield return new WaitForSeconds(5f);
        // Show prompts for venting
        ShowText("Cool off with [Right Click] or [Left Bumper]", 6.9f);
        yield return new WaitForSeconds(7.0f);
        // As a novice mage you have access to two spells
        ShowText("As a novice mage you have access to two spells", 4.9f);
        yield return new WaitForSeconds(5.9f);
        // Show button prompts for switching spells
        ShowText("Press [Q] and [E] or (Y) and (B) to cyle through your spells", 5.9f);
        yield return new WaitForSeconds(6f);
        // In this trial you will fight until you perish, fight for glory.
        ShowText("In this trial you will fight until you perish, fight for glory.", 6.9f);
        yield return new WaitForSeconds(7.0f);
        WaveAnnounce(1);
        StartGame();
    }
    void StartGame()
    {

    }

    void ShowText(string text,float time)
    {
        Transform textObj = Instantiate(textPrefab,textParent);
        textObj.GetComponent<UIFadeAway>().SetTime(time);
        textObj.GetComponent<UnityEngine.UI.Text>().text = text;
    }

}
