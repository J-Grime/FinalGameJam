using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Tool{
    
	// Use this for initialization
	void Start () {
        toolname = "Torch";
        reqMaterials.Add("wood", 20);
        reqMaterials.Add("rock", 0);
        reqMaterials.Add("gunpowder", 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void Primary()
    {

    }
    
}
