using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class breakable : health {

    public GameObject drop;
    public float distanceAllowed;
    public Material outlineMaterial;
    public Material normalMaterial;
    public MeshRenderer meshRenderer;
	
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
        player.GetComponent<InventoryManager>().itemPickup(drop);
    }

    void OnMouseEnter()
    {
        //IF Player is less than X units away:
        //if (Vector3.Distance(transform.position, GameController.Instance.GetPlayer().transform.position) <= distanceAllowed)

        print("Mouse on breakable object");
        meshRenderer.material = outlineMaterial;
        
        //}

    }

    void OnMouseExit()
    {
        print("Mouse moved off of breakable object");
        meshRenderer.material = normalMaterial;
    }
}
