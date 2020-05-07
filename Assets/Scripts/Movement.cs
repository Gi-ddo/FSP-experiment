using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Core Variables")]
    public float mov_speed;
    private Vector3 input_mov;
    private Rigidbody player_rb;
    // Start is called before the first frame update
    void Start()
    {
        player_rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        input_mov = new Vector3(Input.GetAxis("Horizontal"),0 , Input.GetAxis("Vertical") );
        input_mov.Normalize();
        
    }

    void FixedUpdate()
    {
        player_rb.velocity = input_mov * mov_speed;
    }
}
