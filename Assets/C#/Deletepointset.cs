using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deletepointset : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y <= 0.3f)
        {
            Destroy(gameObject);
        }
    }
}