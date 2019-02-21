using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLook : MonoBehaviour {

    public Transform playerBody;
    //move later
    public float damage;

    public bool camLock;
    public GameObject HBGO;
    public HotBar HB;
    public float mouseSensitivity;
    float xAxisClamp;
    public int mult;
    public Tool tooool;

    Ray ray;
    RaycastHit hit;
    private void Start()
    {
        HB = HBGO.GetComponent<HotBar>();
    }
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update ()
    {
        tooool = HB.currentTool;


      //  if (HB.currentTool == null) { Debug.Log("No tool"); }
            rotateCamera();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (HB.currentTool == null) { mult = 1; } else { mult =  HB.currentTool.GetComponent<Tool>().mult; }

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
               if (hit.collider.gameObject.GetComponent<breakable>() != null)
               {
                   
                    
                    hit.collider.gameObject.GetComponent<breakable>().damage(damage, playerBody.gameObject,mult);
               }
            }
        }
    }

    void rotateCamera()
    {
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = MouseX * mouseSensitivity;
        float rotAmountY = MouseY * mouseSensitivity;

        xAxisClamp -= rotAmountY;

        Vector3 targetRotCam = transform.rotation.eulerAngles;
        Vector3 targetRotBody = playerBody.rotation.eulerAngles;

        targetRotCam.x -= rotAmountY;
        targetRotBody.z = 0;
        if (xAxisClamp>90)
            {
                xAxisClamp = 90;
                targetRotCam.x = 90;
            }
        else if (xAxisClamp<-90)
            {
                xAxisClamp = -90;
                targetRotCam.x = 270;
            }

        targetRotBody.y += rotAmountX;

        transform.rotation = Quaternion.Euler(targetRotCam);
        playerBody.rotation = Quaternion.Euler(targetRotBody);
    }
}
