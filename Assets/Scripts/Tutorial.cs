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

    [Header("Practice room text")]
    public GameObject room_intro;
    public GameObject weapon_hint;
    public GameObject room_objective;
    public GameObject bounciness_section;


     void Start()
    {
        Invoke("activate_intro_txt", 15f);
    }

    
    void activate_intro_txt()
    {
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
    }

    public void activate_pract_txt()
    {
        room_intro.SetActive(true);
        weapon_hint.SetActive(true);
        room_objective.SetActive(true);
        bounciness_section.SetActive(true);
    }

    public void disable_prac_txt()
    {
        room_intro.SetActive(false);
        weapon_hint.SetActive(false);
        room_objective.SetActive(false);

    }
}
