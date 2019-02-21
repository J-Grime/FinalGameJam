using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour {

    public string toolname;
    public Hashtable reqMaterials = new Hashtable();
    public int mult;
    // Use this for initialization
    void Start () {
        //toolname = "axe";
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public int getmult() {

        return mult;

    }
    
}
