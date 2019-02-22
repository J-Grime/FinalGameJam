using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCase : MonoBehaviour {
    public GameObject thisCase;
    public GameObject openedCase;
    public GameObject[] suitcase;
    int num;
	// Use this for initialization
	void Start () {
        suitcase = GameObject.FindGameObjectsWithTag("suitcase");
        Debug.Log("amount of cases"+suitcase.Length);
        num = RandomNumber(0, suitcase.Length);
        Debug.Log(num);
        suitcase[num].SetActive(false);
        
	}
	
	// Update is called once per frame
	void Update () {

	}
    public int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return Random.Range(min, max);
    }
}
