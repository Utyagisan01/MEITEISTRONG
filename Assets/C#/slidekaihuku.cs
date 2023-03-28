using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slidekaihuku : MonoBehaviour
{
    public Slider spslider;
    public Slider mpslider;

    public void OnClickSPkaihuku()
    {
        spslider.value = 50;

    }
    public void OnClickMPkaihuku()
    {
        mpslider.value = 0;

    }
}