using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingHeightCheck : MonoBehaviour {

    public bool canPlace;
    public int noOfChecks;

    public Material willPlace, wontPlace;

    float[] checkHeights;

    public float testRadius;
    RaycastHit hit;

    private void Awake()
    {
        checkHeights = new float[noOfChecks];
        for (int i = 0; i < noOfChecks-1; i++)
        {
            checkHeights[i] = 0;
        }
    }


    private void Start()
    {
        float posX = transform.position.x + Random.Range(-testRadius, testRadius);
        float posZ = transform.position.z + Random.Range(-testRadius, testRadius);
        Vector3 randPoint = new Vector3(posX, transform.position.y, posZ);
        for (int i = 0; i < noOfChecks; i++)
        {
            if (Physics.Raycast(randPoint, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
            {
                checkHeights[i] = hit.distance;
            }
        }

    }

    void generateHeightData()
    {
        
        for (int i = 0; i < noOfChecks; i++)
        {
            float posX = transform.position.x + Random.Range(-testRadius, testRadius);
            float posZ = transform.position.z + Random.Range(-testRadius, testRadius);
            Vector3 randPoint = new Vector3(posX, transform.position.y, posZ);

            if (Physics.Raycast(randPoint, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
            {
                if(hit.collider.tag == "ground")
                {
                    checkHeights[i] = hit.distance;
                }
                
            }
        }
    }

    private void Update()
    {
        //Debug.Log("yeeeeeeeeeeeeeeeeeeeeeeeeet");
        generateHeightData();
        canPlace = checkHeightRange(checkHeights);
        if (canPlace)
        {
            gameObject.GetComponent<Renderer>().material = willPlace;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = wontPlace;
        }
    }

    float Max(float[] values)
    {
        float max = float.MinValue;
        foreach (float value in values)
        {
            if (value > max)
            {
                max = value;
            }
        }
        return max;
    }

    float Min(float[] values)
    {
        float min = float.MaxValue;
        foreach (float value in values)
        {
            if (value < min)
            {
                min = value;
            }
        }
        return min;
    }



    bool checkHeightRange(float[] heights)
    {
        Heights(heights);
        bool placeable = false;
        float max = Max(heights);
        float min = Min(heights);

        double range = max - min;

        Debug.Log("MYAR: " + range + ", max: "+ max + ", min: "+ min);

        if (range < .5)
        {
            return placeable = true;
        }
        else
        {
            return placeable;
        }   
    }

    string Heights(float[] heights)
    {
        string heightString = "";
        foreach (float height in heights)
        {
            heightString += ", " + height;
        }
        return heightString;
    }

}
