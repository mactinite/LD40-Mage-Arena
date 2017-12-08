using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfterTime : MonoBehaviour
{
    public float seconds;
    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, seconds);
    }
}
