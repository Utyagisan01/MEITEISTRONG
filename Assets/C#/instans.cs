using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instans : MonoBehaviour
{
    [SerializeField]
    private GameObject obj1;
    [SerializeField]
    private GameObject obj2;


    //true�A�N�e�B�u,false��A�N�e�B�u
    public void objchengi1()
    {
        obj1.SetActive(true);
        obj2.SetActive(false);
 

    }

    //true�A�N�e�B�u,false��A�N�e�B�u
    public void objchengi2()
    {
        obj1.SetActive(false);
        obj2.SetActive(true);


    }

}


