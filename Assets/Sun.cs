using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {
    public Quaternion CurrentRotation;
    public Quaternion TargetRotation;
    public plane PlaneScript;
	// Use this for initialization
	void Start () {
        TargetRotation = new Quaternion(0.3f, -0.7f, 0.3f, 0.6f);

    }
	
	// Update is called once per frame
	void Update () {
		

        //Rotate the sun
        transform.RotateAround(Vector3.zero,Vector3.right,5f*Time.deltaTime);
        transform.LookAt(Vector3.zero);
        CurrentRotation = transform.rotation;
        Debug.Log(CurrentRotation+"   "+TargetRotation);
        if(CurrentRotation == TargetRotation)
        {
            PlaneScript.enabled = true;
        }
	}
}
