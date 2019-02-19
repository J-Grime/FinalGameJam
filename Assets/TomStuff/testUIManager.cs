using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class testUIManager : MonoBehaviour
{
    public Text woodCount;
    public Text stoneCount;
    public Text healthCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<InventoryManager>().inventoryHash["wood"] != null)
        {
            woodCount.text = "Wood: " + gameObject.GetComponent<InventoryManager>().inventoryHash["wood"];
        }
        else
        {
            woodCount.text = "Wood: 0";
        }

        if (gameObject.GetComponent<InventoryManager>().inventoryHash["rock"] != null)
        {
            stoneCount.text = "Rock: " + gameObject.GetComponent<InventoryManager>().inventoryHash["rock"];
        }
        else
        {
           stoneCount.text = "Rock: 0";
        }

        healthCount.text = "health: " + gameObject.GetComponent<playerHealthManager>().hitPoints;

    }
}
