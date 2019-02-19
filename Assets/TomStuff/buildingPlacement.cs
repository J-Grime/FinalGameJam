using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingPlacement : MonoBehaviour {

    public GameObject building;
    public float distance;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.T))
        {
            placeBuilding(building);
        }
	}

    void placeBuilding(GameObject building)
    {
        GameObject newBuilding = Instantiate(building, transform.position + transform.forward * distance, transform.rotation);
        newBuilding.transform.parent = transform;
    }


}
