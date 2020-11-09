using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_jump : MonoBehaviour
{
    [Header("Core Variables")]
    public float jump_velocity;
    public float fall_mod;
    private bool can_jump= true;
    private Rigidbody player_rb;
    private bool jump_request;

     void Start()
    {
        player_rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (player_rb.velocity.y < 0)
        {
            player_rb.velocity += Vector3.up * Physics.gravity.y * (fall_mod) * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.Space)&& can_jump)
        { 
            can_jump = false;
            print(can_jump);
            jump_request = true;
        }
    }

     void FixedUpdate()
    {
        if (jump_request)
        {
            player_rb.AddForce(Vector3.up * jump_velocity, ForceMode.Impulse);
            jump_request = false;
        }
    }

   void OnCollisionEnter(Collision collision)
    {
        print(can_jump);
        if (can_jump == false)
        {

            //can_jump = true;
            if (collision.gameObject.CompareTag("Player"))
            {
                can_jump = true;
            }
        }
    }
}
