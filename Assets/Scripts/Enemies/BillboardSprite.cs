using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardSprite : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    private Vector3 lookDirection;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 oppositeCamera = transform.position - Camera.main.transform.position;
        Quaternion faceCamera = Quaternion.LookRotation(oppositeCamera);
        Vector3 euler = faceCamera.eulerAngles;
        euler.x = 0f;
        faceCamera.eulerAngles = euler;
        transform.rotation = faceCamera;
    }
}
