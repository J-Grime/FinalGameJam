using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingPlacement : MonoBehaviour {

    public GameObject building;

    public float height;
    public float distance;

    private buildingHeightCheck BHC;

    RaycastHit hit;

    GameObject newBuilding;

    private void Start()
    {
        BHC = building.GetComponent<buildingHeightCheck>();
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            displayBuilding(building);
        }

        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log(BHC.canPlace);
            if (BHC.canPlace)
            {
                placeBuilding(building, newBuilding.transform.position);
            }
            
        }
	}

    void displayBuilding(GameObject building)
    {
        Vector3 temp = transform.position + transform.forward * distance;
        Vector3 loc = new Vector3(temp.x, temp.y + height, temp.z);

        newBuilding = Instantiate(building, loc, transform.rotation);
        newBuilding.transform.parent = transform;
    }
    void placeBuilding(GameObject building, Vector3 position)
    {
        if (Physics.Raycast(position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag == "ground")
            {
                Instantiate(building, new Vector3(hit.point.x, hit.point.y+1, hit.point.z), building.transform.rotation);

            }
        }
    }

}
