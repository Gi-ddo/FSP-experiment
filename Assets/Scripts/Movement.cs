using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Core Variables")]
    public float walk_speed;
    public float sprint_speed;
    private Vector3 input_mov;
    private Rigidbody player_rb;
    private float mov_speed;
    void Start()
    {
        player_rb = GetComponent<Rigidbody>();   
    }

    
    void Update()
    {
        input_mov = new Vector3(Input.GetAxis("Horizontal"),0 , Input.GetAxis("Vertical"));
        input_mov.Normalize();

        mov_speed = walk_speed;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            mov_speed = sprint_speed;
        } 
    }

    void FixedUpdate()
    {
        // Make player move in the direction they are facing
        player_rb.velocity = transform.TransformDirection(input_mov) * mov_speed;
    }
}
