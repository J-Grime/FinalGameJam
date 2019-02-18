using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class breakable : MonoBehaviour {

    public float hitPoints;
    public GameObject drop;

	
	// Update is called once per frame
	void Update () {

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void damage(float hitDamage, GameObject player)
    {
        hitPoints -= hitDamage;
        Debug.Log("hit");
     //   player.GetComponent<InventoryManager>().itemPickup(drop);
    }
}
