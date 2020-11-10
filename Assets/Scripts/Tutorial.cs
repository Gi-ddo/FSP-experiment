using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{   
    [Header("Intro room text")]
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject arrow;

    [Header("First tutorial room text")]
    public GameObject room_intro;
    public GameObject weapon_hint;
    public GameObject room_objective;
    public GameObject room_objective2;
    public GameObject clearance;
    public GameObject arrow2;

    [Header("First tutorial objects")]
    public List<GameObject> hoops;
    public int hoops_size;

    [Header("Second tutorial room objects")]
    public List<GameObject> Objs;
    public int size;

    [Header("Second tutorial room text")]
    public GameObject objective;
    public GameObject objective2;
    public GameObject arrow3;

    [Header("Third tutorial room objects")]
    public List<GameObject> platforms;
    public int length;


    [Header("Third tutorial room text")]
    public GameObject bounciness_txt;
    public GameObject instructions;

    
    void Start()
    {
        Invoke("activate_intro_txt", 15f);
    }

    
    void activate_intro_txt()
    {
        Destroy(text1);
        Destroy(text2);
        Destroy(text3);
        Destroy(arrow);

    }

    void activate_2nd_room()
    {
        clearance.SetActive(false);
        arrow2.SetActive(false);
        objective.SetActive(true);
    }

   void activate_2nd_room_items()
    {
        Destroy(objective);

        for (int i = 0; i < size; i++)
        {
            Objs[i].SetActive(true);

        }

    }

    void activate_clearance_2nd_room()
    {
        room_objective2.SetActive(false);
        clearance.SetActive(true);
        arrow2.SetActive(true);
    }

    void activate_third_room()
    {
        objective2.SetActive(false);
        arrow3.SetActive(false);
        instructions.SetActive(true);
    }
    
    void activate_third_room2()
    {
        Destroy(instructions);
        bounciness_txt.SetActive(true);
        for(int i=0; i < length; i++)
        {
            platforms[i].SetActive(true);
        }
            
    }

    void activate_clearance_3rd_room()
    {
        objective2.SetActive(true);
        arrow3.SetActive(true);
    }

    public void activate_tut1_txt()
    {
        room_intro.SetActive(true);
        weapon_hint.SetActive(true);
        room_objective.SetActive(true);
    }

    public void disable_prac_txt()
    {
        Destroy(room_intro);
        Destroy(weapon_hint);
        Destroy(room_objective);

        for(int i=0; i < hoops_size; i++)
        {
            hoops[i].SetActive(true);
        }

        room_objective2.SetActive(true);
    }

    private void Update()
    {
        if( Destroy_projectile.hoops_count <= 0)
        {
            Invoke("activate_clearance_2nd_room", 1f);
        }
        if(Destroy_projectile.obj_count <= 0)
        {
            Invoke("activate_clearance_3rd_room", 1f);
        }
    }
}
