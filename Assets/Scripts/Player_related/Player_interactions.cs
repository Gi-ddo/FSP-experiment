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
            tut.Invoke("activate_tut1_txt", 1f);
            tut.Invoke("disable_prac_txt", 20f);
        }

        if (other.gameObject.CompareTag("active2"))
        {
            tut.Invoke("activate_2nd_room", 1f);
            tut.Invoke("activate_2nd_room_items", 5f);

        }

        if (other.gameObject.CompareTag("active3"))
        {
            tut.Invoke("activate_third_room", 1f);
            tut.Invoke("activate_third_room2", 10f);

        }

    }
}
