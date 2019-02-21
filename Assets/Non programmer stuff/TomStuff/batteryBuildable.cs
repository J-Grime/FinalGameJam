using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batteryBuildable : buildable {

	// Use this for initialization
	void Start () {

        reqMaterials.Add("wood", 120);
        reqMaterials.Add("rock", 150);
        reqMaterials.Add("gunpowder", 100);

    }
}
