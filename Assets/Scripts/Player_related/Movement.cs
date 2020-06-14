using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Core Variables")]
    public float mov_speed;
    [SerializeField] protected Vector3 input_mov;
    [SerializeField] protected Rigidbody player_rb;
    [SerializeField] protected float step_speed = 6f;
    private Quaternion original_rotation;

    void Start()
    {
        player_rb = GetComponent<Rigidbody>();
        original_rotation = transform.rotation;
        player_rb.centerOfMass = Vector3.zero;
        player_rb.inertiaTensorRotation = Quaternion.identity;
    }

    
    void Update()
    {
        input_mov = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
        input_mov.Normalize();

        if (Input.GetKey(KeyCode.B))
        {
            transform.rotation = original_rotation;
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




