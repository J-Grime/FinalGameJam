using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class health : MonoBehaviour {

    public float maxHealth;
    public float hitPoints;


    // Use this for initialization
    void Start () {
        hitPoints = maxHealth;
	}


}
