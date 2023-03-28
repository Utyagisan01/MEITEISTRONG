using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deletepointset1 : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}