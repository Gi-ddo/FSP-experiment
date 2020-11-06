using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_projectile : MonoBehaviour
{
    public ParticleSystem explosion_effect;
    [SerializeField] protected int collision_count;
    public GameObject low;
    public GameObject mid;
    public GameObject high;
    public PhysicMaterial bouncy;
    public static int hoops_count=3;
    public static int obj_count=5;
   
    void OnCollisionEnter(Collision collision)
    {
        collision_count++;

        if(collision_count == 5)
        {
            Instantiate(explosion_effect, transform.position, Quaternion.identity);
            explosion_effect.Play();
            gameObject.SetActive(false);
            collision_count = 0;
        }

        if (collision.gameObject.CompareTag("Level_area"))
        {
            Instantiate(explosion_effect, transform.position, Quaternion.identity);
            explosion_effect.Play();
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Obj"))
        {
            Instantiate(explosion_effect, transform.position, Quaternion.identity);
            explosion_effect.Play();
            obj_count--;
            gameObject.SetActive(false);
            Destroy(collision.gameObject);
           
        }

        if (collision.gameObject.CompareTag("Hoops"))
        {
            Instantiate(explosion_effect, transform.position, Quaternion.identity);
            explosion_effect.Play();
            hoops_count--;
            gameObject.SetActive(false);
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.CompareTag("low"))
        {

            bouncy.bounciness = 0.5f;

        }

        if (collision.gameObject.CompareTag("mid"))
        {

            bouncy.bounciness = 0.7f;
        }

        if (collision.gameObject.CompareTag("high"))
        {

            bouncy.bounciness = 0.9f;
        }


    }

    

}
