using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane : MonoBehaviour {
    Rigidbody RB;
    public int speed;
    public Sun SunScript;
    // Use this for initialization
    Vector3 startPos;
	void Awake () {
        gameObject.SetActive(false);
        startPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        PlaneFly();
	}

    void PlaneFly() {
        if (gameObject.transform.position.z < -150)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);


        }
        else {

            gameObject.transform.position = startPos;
            gameObject.SetActive(false);


        }
        
    }
}



