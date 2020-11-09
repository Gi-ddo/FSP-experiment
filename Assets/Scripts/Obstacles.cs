using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private Vector3 start_pos;
    public float speed;
    public float change;
    public bool is_block;
    public bool is_pipe;

     void Start()
    {
        start_pos = transform.position;
    }

    void Update()
    {
        Vector3 V = start_pos;

        if (is_block)
        {
            V.x += change * Mathf.Sin(Time.time * speed);
            transform.position = V;
        }

        if (is_pipe)
        {
            V.z += change * Mathf.Sin(Time.time * speed);
            transform.position = V;
        }
        

    }
}
