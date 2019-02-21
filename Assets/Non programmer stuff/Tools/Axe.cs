using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Tool {

	// Use this for initialization
	void Start () {
       toolname = "Axe";
        reqMaterials.Add("wood", 10);
        reqMaterials.Add("rock", 10);
        reqMaterials.Add("gunpowder", 0);
        mult = 3;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
