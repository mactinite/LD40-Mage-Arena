using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDisplayManager : MonoBehaviour {

    public static DamageDisplayManager instance;
    public GameObject textPrefab;

	// Use this for initialization
	void Awake () {
        instance = this;
	}


    public void SpawnText(string text,Color textColor ,Transform spawnOn)
    {
        GameObject GO = ObjectPool.Spawn(textPrefab, this.transform, Vector3.zero, Quaternion.identity);
        DamageDisplay dmgDisplay = GO.GetComponent<DamageDisplay>();
        dmgDisplay.riseFrom = spawnOn;
        dmgDisplay.Init();
        dmgDisplay.SetText(text, textColor);
        dmgDisplay.started = true;
    }

}
