using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingPlacement : MonoBehaviour {

    public GameObject building;

    public float height;
    public float distance;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            placeBuilding(building);
        }
	}

    void placeBuilding(GameObject building)
    {
        Vector3 temp = transform.position + transform.forward * distance;
        Vector3 loc = new Vector3(temp.x, temp.y + height, temp.z);

        GameObject newBuilding = Instantiate(building, loc, transform.rotation);
        newBuilding.transform.parent = transform;
    }


}
