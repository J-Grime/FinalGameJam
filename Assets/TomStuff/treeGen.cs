using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class treeGen : MonoBehaviour
{ 
    public float timer = 0;
    public float timediff = 0.9f;
    public Tree baseTree;
    Tree newTree;
    RaycastHit hit;
    public float radius;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float posX = transform.position.x + Random.Range(-radius, radius);
        float posZ = transform.position.z + Random.Range(-radius, radius);
        Vector3 randPoint = new Vector3(posX, transform.position.y, posZ);

<<<<<<< HEAD

        if (timer > timediff)
        { 
            if (Physics.Raycast(randPoint, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
=======
        if (Physics.Raycast(randPoint, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        { 
            if (hit.collider.gameObject.tag == "ground")
>>>>>>> 9689a3bd6c182d5904669613e2a38046ad9869c2
            {
                if (hit.collider.gameObject.tag == "ground")
                {
                    newTree = Instantiate(baseTree, new Vector3(hit.point.x, hit.point.y, hit.point.z), transform.rotation);
                    //newTree.transform.parent = transform;

                }
            }
            timer = 0;
        }
    }
}
