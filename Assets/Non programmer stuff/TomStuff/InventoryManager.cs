using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    public Hashtable inventoryHash = new Hashtable();

    // Use this for initialization
    void Start () {
        inventoryHash.Add("wood", 0);
        inventoryHash.Add("rock", 0);
        inventoryHash.Add("gunpowder", 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            itemsToString();
        }
    }

    public void itemPickup(GameObject newItem)
    {
        string itemName = newItem.GetComponent<itemAttributes>().name;
        Debug.Log(itemName);

        if (inventoryHash.ContainsKey(itemName))
        {
            int currentAmount = (int)inventoryHash[itemName];
            Debug.Log(currentAmount);
            currentAmount++;
            inventoryHash[itemName] = currentAmount;
            Debug.Log((int) inventoryHash[itemName]);
        }
        else
        {
            inventoryHash.Add(itemName, 1);
        }

        newItem.GetComponent<Collider>().enabled = false;
        newItem.GetComponent<Renderer>().enabled = false;
    }

    public void dropItem(int index)
    {
        

        //dropped.transform.position = this.transform.position;
        //dropped.GetComponent<Collider>().enabled = true;
        //dropped.GetComponent<Renderer>().enabled = true;

    }


    public string itemsToString()
    {
        
        string InventoryOutput = "";

        Debug.Log(inventoryHash.Keys.Count);

        foreach (string key in inventoryHash.Keys)
        {
            InventoryOutput += key + " " + (int) inventoryHash[key] + ", ";
        }

        Debug.Log(InventoryOutput);

        return InventoryOutput;
    }
}
