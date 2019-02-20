using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {
    public Quaternion CurrentRotation;
    public Quaternion TargetRotation;
    public GameObject Plane;
	// Use this for initialization
	void Start () {
        TargetRotation = new Quaternion(0.3f, -0.7f, 0.3f, 0.6f);

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 centermap = new Vector3(1000,60,1000);
        
        //Rotate the sun
        transform.RotateAround(centermap,Vector3.right,20f*Time.deltaTime);
        transform.LookAt(centermap);
        CurrentRotation = transform.rotation;
        //Debug.Log(CurrentRotation+"   "+TargetRotation);
        if(CurrentRotation == TargetRotation)
        {
            Debug.Log("equal");
            Plane.SetActive(true);
        }
	}
}
