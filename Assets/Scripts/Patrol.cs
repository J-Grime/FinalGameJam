using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
    private float waitTime;
    public float speed;
    public float startWaitTime;
    public Transform[] moveSpots;
    public int nextSpot;
    bool goBack;
    public FieldOfView Script;

    // Use this for initialization
    void Start() {
        waitTime = startWaitTime;
        nextSpot = 0;
    }

    // Update is called once per frame
    void Update() {
        Script = GameObject.FindObjectOfType(typeof(FieldOfView)) as FieldOfView;
        goBack = Script.GetComponent<FieldOfView>().goBack;
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[nextSpot].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, moveSpots[nextSpot].position) < 0.2f)
        {
            if (nextSpot == moveSpots.Length - 1)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveSpots[0].transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2 * Time.deltaTime);
            }
            else
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveSpots[nextSpot + 1].transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2 * Time.deltaTime);
            }
            
            if (waitTime <= 0)
            {
                nextSpot += 1;
                waitTime = startWaitTime;
                Debug.Log(nextSpot);

            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            

            if (nextSpot == moveSpots.Length) { nextSpot = 0;
                Debug.Log(nextSpot);
            }
        }
    }
}
