using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retrydelete : MonoBehaviour
{

    public void OnClick()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("GameOver");
        foreach (GameObject ball in objects)
        {
            Destroy(ball);
        }
    }
}

