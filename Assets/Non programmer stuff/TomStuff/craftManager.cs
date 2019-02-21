using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craftManager : MonoBehaviour {

    InventoryManager InvManager;
    public GameObject newItem;
    string[] matKeys = new string[3];


    private void Start()
    {
        InvManager = GetComponent<InventoryManager>();
        matKeys[0] = "wood";
        matKeys[1] = "rock";
        matKeys[2] = "gunpowder";
    }

    void craftItem(GameObject item)
    {
        bool materialCheck = checkMaterials(matKeys);

        Debug.Log("MatCheck: " + materialCheck);

        if (materialCheck)
        {
            //set tool access here
        }
    }




    bool checkMaterials(string[] matKeys)
    {
        Debug.Log("Mat check start: " + itemsToString(newItem.GetComponent<Tool>().reqMaterials));

        foreach (string mat in matKeys)
        {
            if ((int)InvManager.inventoryHash[mat] >= (int)newItem.GetComponent<Tool>().reqMaterials[mat])
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
            int newAmount = tempAmount - (int)newItem.GetComponent<Tool>().reqMaterials[mat];
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

}
