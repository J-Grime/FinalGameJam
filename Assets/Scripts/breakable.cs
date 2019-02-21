using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class breakable : health {

    public GameObject drop;

	
	// Update is called once per frame
	void Update () {

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void damage(float hitDamage, GameObject player,int dropMult)
    {
        hitPoints -= hitDamage;
        Debug.Log("hit");
        for (int i = 0;i<dropMult;i++)
        {
            player.GetComponent<InventoryManager>().itemPickup(drop);
        }
        
    }
}
