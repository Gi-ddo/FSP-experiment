using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [Header("Variables")]
    public float swayInt;
    public float swaySnap;


    private Quaternion originRot;
    // Start is called before the first frame update
    void Start()
    {
        originRot = transform.localRotation;
    }

    

    // Update is called once per frame
    void Update()
    {
        updateSway();
    }

    void updateSway()
    {
        float xMouse = Input.GetAxisRaw("Mouse X");
        float yMouse = Input.GetAxisRaw("Mouse Y");

        Quaternion xAdj = Quaternion.AngleAxis(-swayInt * xMouse, Vector3.up*swaySnap);
        Quaternion yAdj = Quaternion.AngleAxis(swayInt * yMouse, Vector3.right * swaySnap);
        Quaternion targetRot = originRot * xAdj * yAdj;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRot, swaySnap * Time.deltaTime);

    }
}
