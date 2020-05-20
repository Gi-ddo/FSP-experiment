using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_projectile : MonoBehaviour
{
    [SerializeField] protected int collision_count;
     
     void OnCollisionEnter(Collision collision)
    {
        collision_count++;
        print(collision_count);

        if(collision_count >= 4)
        {
            gameObject.SetActive(false);
            collision_count = 0;
        }

        if (collision.gameObject.CompareTag("Outside"))
        {
            gameObject.SetActive(false);
        }
        
            
       
    }

}
