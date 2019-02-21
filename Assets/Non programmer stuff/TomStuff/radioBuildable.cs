using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radioBuildable : buildable {

	// Use this for initialization
	void Start () {
        reqMaterials.Add("wood", 1000);
        reqMaterials.Add("rock", 1000);
        reqMaterials.Add("gunpowder", 1000);
    }
}
