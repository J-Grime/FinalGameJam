﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "player")
        {
            
            other.GetComponent<playerHealthManager>().damage(5);
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()

    {
        yield return new WaitForSeconds(5);
    }
}
