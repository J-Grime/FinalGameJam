using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class craftButton : MonoBehaviour {
    public GameObject craftObject;
    public Button thisButton;
    public Canvas buildMenu;

    private void Start()
    {
        thisButton.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        GameObject.FindGameObjectWithTag("player").GetComponent<craftManager>().newItem = craftObject;


        buildMenu.enabled = false;
    }



}
