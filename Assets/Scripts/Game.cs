using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    GameObject[] campfires;
    GameObject[] SOS;
    GameObject[] Radio;
    GameObject[] Flare;
    int score;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        campfires = GameObject.FindGameObjectsWithTag("campfire");
        Debug.Log("length is  "+campfires.Length);
	}
}
