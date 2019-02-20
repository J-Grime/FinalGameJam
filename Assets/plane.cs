using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane : MonoBehaviour {
    Rigidbody RB;
    public int speed;
    public Sun SunScript;
    GameObject script;
	// Use this for initialization
	void Start () {
        script.SetActive(false);
        script.GetComponent<plane>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        PlaneFly();
	}

    void PlaneFly() {
        transform.Translate(Vector3.right * Time.deltaTime*speed);
    }
}



