using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeBuildable : buildable {

    private void Start()
    {
        reqMaterials.Add("wood", 12);
        reqMaterials.Add("rock", 15);
        reqMaterials.Add("metal", 0);
    }
}
