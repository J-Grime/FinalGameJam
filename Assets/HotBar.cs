using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotBar : MonoBehaviour {
    public int selectedSpace;
    public Text spacetext;
    public Torch torch1;
    public Axe axe1;
    public Light torchLight;
    public Text currentToolText;
    public Tool[] listOfTools;
    Tool currentTool;
	// Use this for initialization
	void Start () {
        selectedSpace = 4;
        
        listOfTools = new Tool[9];
        listOfTools[0] = torch1;
        listOfTools[1] = axe1;
        listOfTools[2] = axe1;
        listOfTools[3] = axe1;
        listOfTools[4] = axe1;
        listOfTools[5] = axe1;
        listOfTools[6] = axe1;
        listOfTools[7] = axe1;
        listOfTools[8] = axe1;
        currentTool = listOfTools[selectedSpace];
    }
	
	// Update is called once per frame
	void Update () {
        HotbarCycle();
        currentTool = listOfTools[selectedSpace];
        currentToolText.text = currentTool.GetComponent<Tool>().toolname;
        UseTool();
	}

    void HotbarCycle() {
        int lastSpace;
        if (Input.mouseScrollDelta.y < 0)
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
            CheckSwitch(selectedSpace);
        }//scolling down
        if (Input.mouseScrollDelta.y > 0)
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
            CheckSwitch(selectedSpace);
        }//scrolling up
        spacetext.text = "count:" + selectedSpace.ToString();

        if (Input.GetKey("1")) { lastSpace = selectedSpace; selectedSpace = 0; CheckSwitch(lastSpace); }
        if (Input.GetKey("2")) { lastSpace = selectedSpace; selectedSpace = 1; CheckSwitch(lastSpace); }
        if (Input.GetKey("3")) { lastSpace = selectedSpace; selectedSpace = 2; CheckSwitch(lastSpace); }
        if (Input.GetKey("4")) { lastSpace = selectedSpace; selectedSpace = 3; CheckSwitch(lastSpace); }
        if (Input.GetKey("5")) { lastSpace = selectedSpace; selectedSpace = 4; CheckSwitch(lastSpace); }
        if (Input.GetKey("6")) { lastSpace = selectedSpace; selectedSpace = 5; CheckSwitch(lastSpace); }
        if (Input.GetKey("7")) { lastSpace = selectedSpace; selectedSpace = 6; CheckSwitch(lastSpace); }
        if (Input.GetKey("8")) { lastSpace = selectedSpace; selectedSpace = 7; CheckSwitch(lastSpace); }
        if (Input.GetKey("9")) { lastSpace = selectedSpace; selectedSpace = 8; CheckSwitch(lastSpace); }
    }
    void CheckSwitch(int last)
    {
        if(listOfTools[last].GetComponent<Tool>().toolname != currentTool.GetComponent<Tool>().toolname)
        {
           // SwitchTool();
        }
    }
    void SwitchTool(Tool changeto)
    {
        currentTool = changeto;
    }
    void UseTool()
    {
        if (currentTool.GetComponent<Tool>().toolname == "Torch")
        {
            torchLight.enabled = true;
        }else { torchLight.enabled = false; }
    }
}
