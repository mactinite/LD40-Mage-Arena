using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public Transform textPrefab;
    public Transform textParent;

    public int CurrentWave = 1;
    public int maxWaves = 50;
    public AnimationCurve difficultyCurve;

    public static Transform Player;
    public bool gameEnabled = true;

    int currentEnemyProgression = 0;
    public Transform[] spawnPoints;
    public Transform[] enemies;

    public List<GameObject> currentEnemies = new List<GameObject>();
    public bool Spawning = false;
    public bool WaveStarted = false;
    public bool skipIntro = false;
    public float waveTimer = 0;


    public Transform victoryScreen;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            instance.victoryScreen = this.victoryScreen;
            instance.textParent = this.textParent;
            Destroy(gameObject);
        }

        Player = GameObject.FindGameObjectWithTag("Player").transform;

        DontDestroyOnLoad(this);
        if (gameEnabled && !skipIntro)
        {
            StartCoroutine("IntroSequence");
        }


    }


    void Init()
    {

        StopCoroutine("IntroSequence");
        StopCoroutine("WaveAnnounce");
        StopCoroutine("SpawnEnemies");
        StopCoroutine("WaveUpdate");
        StopCoroutine("EndGame");
        currentEnemies.Clear();
        Spawning = false;
        WaveStarted = false;
        skipIntro = false;
        CurrentWave = 1;
        currentEnemyProgression = 0;
        StartCoroutine("WaveAnnounce",1);
    }

    IEnumerator WaveAnnounce(int wave)
    {
        ShowText("Wave " + wave, 4.9f);
        yield return new WaitForSeconds(5f);
        StartWave(wave);
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
        ShowText("The Arena is an ethereal plane. We are going to test your self control.", 4.9f);
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
        ShowText("In this trial you will need to survive through 50 undead hordes, fight for glory.", 6.9f);
        yield return new WaitForSeconds(7.0f);
        StartCoroutine("WaveAnnounce", 1);
        
    }


    IEnumerator SpawnEnemies(int count)
    {        
        if(count == 0)
        {
            count = 1;
        }
        for (int i = 0; i < count; i++)
        {
            int enemyToSelect = Random.Range(0, currentEnemyProgression + 1);
            Transform enemy = Instantiate(enemies[enemyToSelect], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            currentEnemies.Add(enemy.gameObject);
            yield return new WaitForSeconds(Random.Range(0.1f, 1f));
        }
        Spawning = false;
        StartCoroutine("WaveUpdate");
    }

    void StartWave(int waveNumber)
    {
        if(waveNumber > 50)
        {
            StartCoroutine("EndGame");
        }

        if(waveNumber == 3)
        {
            currentEnemyProgression = 1;
        }
        WaveStarted = true;
        Spawning = true;
        StartCoroutine("SpawnEnemies",Mathf.CeilToInt(difficultyCurve.Evaluate(waveNumber)));
    }


    IEnumerator WaveUpdate()
    {
        yield return new WaitUntil(WaveEnded);

        CurrentWave++;
        StartCoroutine("WaveAnnounce",CurrentWave);

    }

    IEnumerator EndGame()
    {
        victoryScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        Application.Quit();
    }

    public bool WaveEnded()
    {
        if(currentEnemies.Count <= 0)
        {
            return true;
        }

        return false;
    }

    public void EnemyDied(GameObject enemy)
    {
        if (currentEnemies.Contains(enemy))
        {
            currentEnemies.Remove(enemy);
        }
    }

    public void OnPlayerDead()
    {
        // Restart, but with intro skipped
        skipIntro = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.sceneLoaded += (Scene scene, LoadSceneMode mode) => { Init(); };
    }


    void ShowText(string text,float time)
    {
        Transform textObj = Instantiate(textPrefab,textParent);
        textObj.GetComponent<UIFadeAway>().SetTime(time);
        textObj.GetComponent<UnityEngine.UI.Text>().text = text;
    }

}
