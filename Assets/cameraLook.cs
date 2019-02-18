using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLook : MonoBehaviour {

    public Transform playerBody;
    //move later
    public float damage;

    public float mouseSensitivity;
    float xAxisClamp;

    Ray ray;
    RaycastHit hit;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update ()
    {
        
        rotateCamera();

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
              //  if (hit.collider.gameObject.GetComponent<breakable>() != null)
               // {
              //      hit.collider.gameObject.GetComponent<breakable>().damage(damage, playerBody.gameObject);
              //  }
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
