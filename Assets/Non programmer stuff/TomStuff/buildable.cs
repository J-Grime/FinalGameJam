using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class buildable : MonoBehaviour {

    public Hashtable reqMaterials = new Hashtable();
    public Material mat;
}
