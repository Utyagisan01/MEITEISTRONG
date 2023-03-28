using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class kakusiEvent : MonoBehaviour
{
    public GameObject[] Prefabs;
    private int number;
    private Vector3 mousePosition;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            number = Random.Range(0, Prefabs.Length);
            mousePosition = Input.mousePosition;

            mousePosition.z = 2.2f;
            Instantiate(Prefabs[number], Camera.main.ScreenToWorldPoint(mousePosition), Quaternion.identity);

        }
    }
}