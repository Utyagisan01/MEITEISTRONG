using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ButtonEvent3 : MonoBehaviour
{
    public GameObject[] Prefabs;
    private int number;
   
    public void OnClick()
    {
        number = Random.Range(0, Prefabs.Length);
        float x = Random.Range(-1.1f, -0.7f);
        float z = Random.Range(-0.3f, -0.8f);
        Vector3 pos = new Vector3(x, 2f, z);

        Instantiate(Prefabs[number], pos, Quaternion.Euler(10, -75, 12));

    }
}