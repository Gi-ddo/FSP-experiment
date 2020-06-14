using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_interactions : MonoBehaviour
{

    public GameObject weapon;
    public Tutorial tut;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("active"))
        {
            weapon.SetActive(true);
            tut.Invoke("activate_pract_txt", 1f);
            tut.Invoke("disable_prac_txt", 35f);
        }
    }
}
