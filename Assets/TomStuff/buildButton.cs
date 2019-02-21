using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class buildButton : MonoBehaviour {

    public GameObject buildObject;
    public Button thisButton;
    public Canvas buildMenu;

    private void Start()
    {
        thisButton.onClick.AddListener(TaskOnClick);  
    }

    private void TaskOnClick()
    {
        GameObject.FindGameObjectWithTag("player").GetComponentInChildren<buildingPlacement>().building = buildObject;
        GameObject.FindGameObjectWithTag("player").GetComponentInChildren<buildingPlacement>().displayBuilding(buildObject);

        buildMenu.enabled = false;
    }
}
