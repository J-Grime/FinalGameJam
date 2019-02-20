using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectHealthBarMovement : MonoBehaviour {

    RectTransform canvas;
    public GameObject player;

    private void Start()
    {
        canvas = GetComponentInChildren<RectTransform>();
    }

    // Update is called once per frame
    void Update () {
        canvas.LookAt(player.transform);
	}
}
