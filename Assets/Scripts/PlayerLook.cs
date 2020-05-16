using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{   
    // Sensitivity for player look and cam look
   [Header("Variables")]
    public float XmouseSens;
    public float YmouseSens;

    // rotation along the x-axis of the camera
      public float maxCamRotAngle;

    // camera center rotation
    private Quaternion camCenter;

    // player ref camera and player
    public Transform fpsCam;
    public Transform playerRef;

   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        camCenter = fpsCam.localRotation;
    }

    // Camera  controls on Y axis
    void camMouse()
    {
        float mouseY = Input.GetAxis("Mouse Y") * YmouseSens * Time.deltaTime;

        // Takes the Y mouse input from player and creates a rotation on the X axis
        Quaternion rotAdj = Quaternion.AngleAxis(mouseY, -Vector3.right);

        //  Adds the rotation on the reference rotation of the camera
        Quaternion changeInRot = fpsCam.localRotation * rotAdj;

        // Checks the max rotation a player can make
        if(Quaternion.Angle(camCenter,changeInRot) < maxCamRotAngle)
        {
            fpsCam.localRotation = changeInRot;
        }
      
    }

   // Player camera controls on X axis
    void playerMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * XmouseSens * Time.deltaTime;
        Quaternion rotAdj = Quaternion.AngleAxis(mouseX, Vector3.up);
        Quaternion changeInRot = playerRef.localRotation * rotAdj;
        playerRef.localRotation = changeInRot; 
    }

    
    void Update()
    {
        camMouse();
        playerMouse();
        
    }
}
