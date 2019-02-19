using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class treeGen : MonoBehaviour
{ 

    public Tree baseTree;
    Tree newTree;
    RaycastHit hit;
    public float radius;

    // Update is called once per frame
    void Update()
    {
        float posX = transform.position.x + Random.Range(-radius, radius);
        float posZ = transform.position.z + Random.Range(-radius, radius);
        Vector3 randPoint = new Vector3(posX, transform.position.y, posZ);

        if (Physics.Raycast(randPoint, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        { 
            if (hit.collider.gameObject.tag == "ground")
            {
                newTree = Instantiate(baseTree, new Vector3(hit.point.x, hit.point.y-2, hit.point.z), transform.rotation);

            }
        }
    }
}
