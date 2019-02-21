using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour {

    public string toolname;
    public Hashtable reqMaterials = new Hashtable();
    // Use this for initialization
    void Start () {
        //toolname = "axe";
        reqMaterials.Add("wood", 10);
        reqMaterials.Add("rock", 10);
        reqMaterials.Add("gunpowder", 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    
}
