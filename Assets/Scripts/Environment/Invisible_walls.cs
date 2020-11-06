using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible_walls : MonoBehaviour
{
    public GameObject intro_wall;
    public GameObject room2_wall;
    public GameObject room3_wall;
    

   void remove_intro_wall()
    {
        intro_wall.SetActive(false);
    }

   void remove_room2_wall()
    {

    }
    void Update()
    {
        
    }
}
