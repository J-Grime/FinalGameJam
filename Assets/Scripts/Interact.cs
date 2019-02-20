using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    //Materials to be set in editor
    public Material outlineMaterial;
    public Material normalMaterial;
    public Material redMaterial;

    MeshRenderer meshRenderer;

    public float distanceAllowed = 10;

    private bool interacted;
    private bool canInteract;

    private void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                InteractWith();
            }
        }
    }

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void OnMouseOver()
    {
        //IF Player is less than X units away:
        if (Vector3.Distance(transform.position, GameController.Instance.GetPlayer().transform.position) <= distanceAllowed)
        {
            if (interacted == false)
            {
                meshRenderer.material = outlineMaterial;
            }
            canInteract = true;
        }

    }

    void OnMouseExit()
    {
        if (interacted == false)
        {
            meshRenderer.material = normalMaterial;
        }
        canInteract = false;
    }

    void InteractWith()
    {
        if (gameObject.tag == "item")
        {
            //Inventory.add(itemName);
            Destroy(gameObject);
        }
        else if (gameObject.tag == "interactable")
        {
            //interact
            TurnRed();
        }
    }

    void TurnRed()
    {
        //Example interaction, can change to "turn radio on" or something ?
        interacted = true;
        meshRenderer.material = redMaterial;
    }
}
