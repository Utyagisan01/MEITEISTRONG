using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ButtonEvent2 : MonoBehaviour
{
    public GameObject[] Prefabs;
    private int number;

    public void OnClick()
    {
        number = Random.Range(0, Prefabs.Length);
        float x = Random.Range(0.0f, 0.0f);
        float z = Random.Range(0.0f, 0.0f);
        Vector3 pos = new Vector3(x, 0f, z);

        Instantiate(Prefabs[number], pos, Quaternion.Euler(0, 0, 0));

    }
}