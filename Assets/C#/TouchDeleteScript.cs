using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDeleteScript : MonoBehaviour
{

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Delete")
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}