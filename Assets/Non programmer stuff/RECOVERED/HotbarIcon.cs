using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarIcon : MonoBehaviour {

    HotBar HB;
    public GameObject player;

    public float movex;
    public float movey;

    public Texture Empty;
    public Texture axe;
    public Texture torch;
    //public float xmove;
   // public Y
   // Transform placetoreturnto;
   
    public RawImage[] icons = new RawImage[9];
    int selectedItem;
    public Vector3[] StartTransforms= new Vector3[9];
    public Vector3[] desiredLocs = new Vector3[9];
    
	// Use this for initialization
	void Start () {
        HB = player.GetComponent<HotBar>();
        // placetoreturnto = this.transform;
        for (int i = 0; i < icons.Length; i++)
        {
            printVector(icons[i].rectTransform.position);
            StartTransforms[i] = icons[i].rectTransform.position;
        }
        for (int i = 0; i < icons.Length; i++)
        {
            
            desiredLocs[i] = new Vector3(StartTransforms[i].x + movex, StartTransforms[i].y + movey, 0.0f);
        }
       }
	
	// Update is called once per frame
	void Update () {
        selectedItem = HB.selectedSpace;
       // icons[selectedItem].color = Color.white;
        MoveIcon(selectedItem);
        for (int i = 0; i < icons.Length; i++)
        {
            
            UpdateIcons(i);

            if (i!= selectedItem)
            {
              // icons[i].color = Color.grey;
               icons[i].rectTransform.position = StartTransforms[i];
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

    void MoveIcon(int i)
    {
        icons[i].rectTransform.position = desiredLocs[i];
    }

    string printVector(Vector3 v)
    {
        string output = "";
        output = "" + v.x + ", " + v.y + ", " + v.z;
        return output;
    }

}
