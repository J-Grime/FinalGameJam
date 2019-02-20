using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectHealthBarMovement : MonoBehaviour {

    RectTransform canvas;
    GameObject player;

    void Start()
    {
        canvas = GetComponentInChildren<RectTransform>();
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update () {
        
        canvas.LookAt(player.transform);
	}
}
