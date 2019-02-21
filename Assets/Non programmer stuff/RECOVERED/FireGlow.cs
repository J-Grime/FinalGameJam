using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGlow : MonoBehaviour {
    Light thislight;
    float rand;
    
    bool direction = true;
	// Use this for initialization
	void Start () {
        thislight = this.GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
       if (direction == true){thislight.intensity++; rand = Random.Range(1,3); }
        if (direction == false) { thislight.intensity--; rand = Random.Range(1,3); }

        if (thislight.intensity > 9+rand) { direction = false; }
        if (thislight.intensity < 8-rand) { direction = true; }
    }
}
