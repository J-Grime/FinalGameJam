using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class buildingPlacement : MonoBehaviour {

    string[] matKeys = new string[3];

    bool displayingBuilding = false;

    public GameObject building;

    public float height;
    public float distance;

    private buildingHeightCheck BHC = null;

    private InventoryManager InvManager = null;

    RaycastHit hit;

    GameObject newBuilding;

    public Canvas buildMenu;

    private void Start()
    {
        //BHC = building.GetComponent<buildingHeightCheck>();
        InvManager = transform.parent.GetComponentInParent<InventoryManager>();
        matKeys[0] = "wood";
        matKeys[1] = "rock";
        matKeys[2] = "metal";
        buildMenu.enabled = false;
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (buildMenu.enabled == false)
            {
                GetComponentInParent<cameraLook>().camLock = true;
                buildMenu.enabled = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                hideItem(newBuilding);
                GetComponentInParent<cameraLook>().camLock = false;
                buildMenu.enabled = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            //displayBuilding(building);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (BHC != null)
            {
                if (displayingBuilding)
                { 
                    //Debug.Log(BHC.canPlace);

                    bool materialCheck = checkMaterials(matKeys);

                    Debug.Log("MatCheck: " + materialCheck);

                    if (BHC.canPlace && materialCheck)
                    {
                        placeBuilding(building, newBuilding.transform.position);
                        Destroy(newBuilding);
                        displayingBuilding = false;
                    }
                }
            }
        }
	}

    public void displayBuilding(GameObject building)
    {
        displayingBuilding = true;
        Vector3 temp = transform.position + transform.forward * distance;
        Vector3 loc = new Vector3(temp.x, temp.y + height, temp.z);

        newBuilding = Instantiate(building, loc, transform.rotation);
        newBuilding.transform.parent = transform;
        BHC = newBuilding.GetComponent<buildingHeightCheck>();
        Cursor.lockState = CursorLockMode.Locked;
        GetComponentInParent<cameraLook>().camLock = false;
    }
    void placeBuilding(GameObject building, Vector3 position)
    {
        if (Physics.Raycast(position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag == "ground")
            {
                GameObject built = Instantiate(building, new Vector3(hit.point.x, hit.point.y+1, hit.point.z), building.transform.rotation);
                Destroy(built.GetComponent<buildable>());
                Destroy(built.GetComponent<buildingHeightCheck>());
                built.gameObject.GetComponent<Renderer>().material = newBuilding.GetComponent<buildable>().mat;
            }
        }
    }

    bool checkMaterials(string[] matKeys)
    {
        Debug.Log("Mat check start: " + itemsToString(newBuilding.GetComponent<buildable>().reqMaterials));

        foreach (string mat in matKeys)
        {
            if ((int)InvManager.inventoryHash[mat] >= (int)newBuilding.GetComponent<buildable>().reqMaterials[mat])
            {
                Debug.Log("key " + mat + " matches");

            }
            else
            {
                return false;
            }
        }
        foreach (string mat in matKeys)
        { 
        int tempAmount = (int)InvManager.inventoryHash[mat];
        int newAmount = tempAmount - (int)newBuilding.GetComponent<buildable>().reqMaterials[mat];
        InvManager.inventoryHash[mat] = newAmount;
        }
        return true;
    }

    public string itemsToString(Hashtable inv)
    {

        string InventoryOutput = "";

        foreach (string key in inv.Keys)
        {
            InventoryOutput += key + " " + (int)inv[key] + ", ";
        }

        return InventoryOutput;
    }
    void hideItem(GameObject CurrentBuilding)
    {
        if (displayingBuilding)
        {
            Destroy(CurrentBuilding);
        }
        else { }
    }
}
