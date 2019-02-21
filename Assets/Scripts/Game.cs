using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour {
    public Object scenetoload;
    GameObject[] campfires;
    GameObject[] SOS;
    GameObject[] Radio;
    GameObject[] Flare;
    int score;
	// Use this for initialization
	void Awake () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        campfires = GameObject.FindGameObjectsWithTag("campfire");
        SOS = GameObject.FindGameObjectsWithTag("SOS");
        Radio = GameObject.FindGameObjectsWithTag("radio");
        Flare = GameObject.FindGameObjectsWithTag("Flare");

        if (campfires.Length >= 3)
        { score += 9; }
        else
        { score += campfires.Length * 3; }
        




        if (SOS.Length >= 3)
        { score += 15; }
        else { score += SOS.Length * 5; }

        if (Radio.Length >= 1)
        { score += 75; }

        if (Flare.Length >= 1)
        { score += 25; }







        Debug.Log("score is     "+ score);


        if (score >= 100)
        {
            Debug.Log("Rescued");
            //SceneManager.LoadScene(scenetoload.name);
        }
        score = 0;
        this.enabled = false;
    }
}
