using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {

    // for when inventory is implemented: 
    //public Inventory inventory; 

    private bool isPaused;

    //can get player from any script which is nice tee hee
    public GameObject player;  

	// Use this for initialization
	void Start () {
        //for now pretend the camera is the player ok
        player = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {

	}

    public GameObject GetPlayer()
    {
        return player;
    }

    public void PauseGame() {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }


    }
}
