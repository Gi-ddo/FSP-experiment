using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Core Variables")]
    public float walk_speed;
    public float sprint_speed;
    [SerializeField] protected Vector3 input_mov;
    [SerializeField] protected Rigidbody player_rb;
    [SerializeField] protected float mov_speed;
    [SerializeField] protected float step_speed = 6f;

    void Start()
    {
        player_rb = GetComponent<Rigidbody>();   
    }

    
    void Update()
    {
        input_mov = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
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
        Vector3 newPos = transform.TransformDirection(input_mov) * mov_speed;
        player_rb.velocity = Vector3.Lerp(player_rb.velocity, newPos, step_speed * Time.fixedDeltaTime);
        player_rb.angularVelocity = Vector3.zero;
    }
}




