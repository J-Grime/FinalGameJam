using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBuildable : buildable {

    // Use this for initialization
    void Start () {
        reqMaterials.Add("wood", 6);
        reqMaterials.Add("rock", 6);
        reqMaterials.Add("gunpowder", 0);
	}
}
