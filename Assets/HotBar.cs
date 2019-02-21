using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotBar : MonoBehaviour
{
    public GameObject hands;
    
    public GameObject torchGO;
    public GameObject axeGO;
    public int selectedSpace;
    // public Text spacetext;
    public Torch torch1;
    public Axe axe1;
    public Light torchLight;
    //public Text currentToolText;
    public Tool[] listOfTools;
    public Tool currentTool;
    // Use this for initialization
    void Start()
    {
        
        selectedSpace = 4;

       
        listOfTools = new Tool[9];
        listOfTools[0] = torch1;
        listOfTools[1] = axe1;
        
        currentTool = listOfTools[selectedSpace];
    }

    // Update is called once per frame
    void Update()
    {
        HotbarCycle();
        currentTool = listOfTools[selectedSpace];

        UseTool();
    }

    void HotbarCycle()
    {
        int lastSpace;
        if (Input.mouseScrollDelta.y > 0)
        {
            lastSpace = selectedSpace;
            if (selectedSpace > 0)
            {
                selectedSpace--;
                
            }
            else if (selectedSpace == 0)
            {
                selectedSpace = 8;
                
            }
            CheckSwitch();
        }//scolling down
        if (Input.mouseScrollDelta.y < 0)
        {
            lastSpace = selectedSpace;
            if (selectedSpace < 8)
            {
                selectedSpace++;
                
            }
            else if (selectedSpace == 8)
            {
                selectedSpace = 0;
                
            }
            CheckSwitch();
        }//scrolling up
        //spacetext.text = "count:" + (selectedSpace+1).ToString();

        if (Input.GetKey("1")) { selectedSpace = 0; CheckSwitch(); }
        if (Input.GetKey("2")) { selectedSpace = 1; CheckSwitch(); }
        if (Input.GetKey("3")) { selectedSpace = 2; CheckSwitch(); }
        if (Input.GetKey("4")) { selectedSpace = 3; CheckSwitch(); }
        if (Input.GetKey("5")) { selectedSpace = 4; CheckSwitch(); }
        if (Input.GetKey("6")) { selectedSpace = 5; CheckSwitch(); }
        if (Input.GetKey("7")) { selectedSpace = 6; CheckSwitch(); }
        if (Input.GetKey("8")) { selectedSpace = 7; CheckSwitch(); }
        if (Input.GetKey("9")) { selectedSpace = 8; CheckSwitch(); }
    }
    void CheckSwitch()
    {
        currentTool = listOfTools[selectedSpace];
        if (currentTool == null)
        {
            hands.SetActive(true);
            torchGO.SetActive(false);
            axeGO.SetActive(false);
        }
        else
        {
            hands.SetActive(false);
            if (currentTool.GetComponent<Tool>().toolname == "Torch") { torchGO.SetActive(true); } else { torchGO.SetActive(false); }
            if (currentTool.GetComponent<Tool>().toolname == "Axe") { axeGO.SetActive(true); } else { axeGO.SetActive(false); }

        }

    }

    void UseTool()
    {
        if (currentTool != null)
        {
            if (currentTool.GetComponent<Tool>().toolname == "Torch")
            {
                torchLight.enabled = true;
            }
            else { torchLight.enabled = false; }
        }
        else { torchLight.enabled = false; }
    }
}