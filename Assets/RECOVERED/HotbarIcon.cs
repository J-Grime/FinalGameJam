using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarIcon : MonoBehaviour {

    HotBar HB;
    public GameObject player;

    public Texture Empty;
    public Texture axe;
    public Texture torch;
    

    public RawImage[] icons = new RawImage[9];
    int selectedItem;
    
	// Use this for initialization
	void Start () {
        HB = player.GetComponent<HotBar>();
	}
	
	// Update is called once per frame
	void Update () {
        selectedItem = HB.selectedSpace;
        icons[selectedItem].color = Color.white;
        for (int i = 0; i < icons.Length; i++)
        {

            UpdateIcons(i);

            if (i!= selectedItem)
            {
                icons[i].color = Color.grey;
            }
        }
	}
    void UpdateIcons(int i)
    {

        if (HB.listOfTools[i] != null)
        {
            if (HB.listOfTools[i].GetComponent<Tool>().toolname == "Axe") { icons[i].texture = axe; }
            if (HB.listOfTools[i].GetComponent<Tool>().toolname == "Torch") { icons[i].texture = torch; }
        }
        else { icons[i].texture = Empty; }
    }
}
