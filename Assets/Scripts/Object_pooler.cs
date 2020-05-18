using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Object_pooler : MonoBehaviour
{
    public static Object_pooler current;
    public List<GameObject> object_pool;
    public GameObject polled_object;
    public int pool_amount;


    void Awake()
    {
        current = this;
    }


    void Start()
    {
        object_pool = new List<GameObject>();
        for(int i=0; i<pool_amount; i++)
        {
            GameObject obj = (GameObject)Instantiate(polled_object);
            obj.SetActive(false);
            object_pool.Add(obj);
        }
    }

    public GameObject Get_polled_object()
    {
        for(int i=0;i< object_pool.Count; i++)
        {
            if (!object_pool[i].activeInHierarchy)
            {
                return object_pool[i];
            }
        }

        return null;
    }


}
