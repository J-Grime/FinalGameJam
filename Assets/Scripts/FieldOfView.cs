using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour {

    // Use this for initialization
    public Patrol Script;
    public float viewRadius;
    bool isTargetInRange;
    [Range(0,360)]
    public float viewAngle;
    Rigidbody guard;
    public LayerMask targetMask;
    public LayerMask obstaclesMask;
    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();
    public bool goBack;
    bool waitActive = false;
    public Quaternion rotation;
    Vector3 pos;
    
    void Start()
    {
        //StartCoroutine("FindTargetsWithDelay", .2f);
        Script = GameObject.FindObjectOfType(typeof(Patrol)) as Patrol;
        Script.enabled = false;
        isTargetInRange = false;
        goBack = false;
    }
    
    void Update()
    {
        
        Transform[] moveSpots = Script.GetComponent<Patrol>().moveSpots;
        int nextSpot = Script.GetComponent<Patrol>().nextSpot;
        FindVisableTargets();
        guard = GetComponent<Rigidbody>();
        
        //checks if target is in range
        if (transform.position == pos) { goBack = false; }
        if (!isTargetInRange && goBack == false)
        {
            
            Script.enabled = true;
            goBack = false;

        }
        else if(!isTargetInRange && goBack == true && !(transform.position == pos) )
        {
            //looks back to original point
            
            Script.enabled = false;


            //RotateToLastPoint(moveSpots, nextSpot);


            //StartCoroutine(Wait());
            transform.position = Vector3.MoveTowards(transform.position, moveSpots[nextSpot].position, 5 * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(moveSpots[nextSpot].transform.position - transform.position);
            rotation = targetRotation;
            Debug.Log(targetRotation );
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 4 * Time.deltaTime);
            
            //Debug.Log(goBack);
            pos = moveSpots[nextSpot].position;
            if (transform.position == pos) { goBack = false; }
            //Script.enabled = true;
        }
        else
        {

            //looks and moves towards player
            transform.position = Vector3.MoveTowards(transform.position, visibleTargets[0].position, 5 * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(visibleTargets[0].transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
            Script.enabled = false;
            
            goBack = true;
        }
        isTargetInRange = false;
        
    }
    void RotateToLastPoint(Transform[] moveSpots, int nextSpot) {
        
    }
    IEnumerator Wait()
    {
        waitActive = true;
        yield return new WaitForSeconds(10f);
        waitActive = false;
    }
    void FindVisableTargets()
    {
        
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward,dirToTarget)<viewAngle/2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstaclesMask))
                {
                    visibleTargets.Add(target);
                    isTargetInRange = true;
                }
                RaycastHit Hit;
                if (Physics.Raycast(transform.position, dirToTarget, out Hit, 1000))
                {
                    if (Hit.collider.gameObject.name == "player")
                    {
                        
                        
                    }
                }
            }
        }
    }
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal) { angleInDegrees += transform.eulerAngles.y; }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
