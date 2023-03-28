using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIを使うときに書きます。

public class sliderattack : MonoBehaviour
{
    public Slider spslider;
    public Slider mpslider;

    void Start()
    {
        spslider.value = 0;
        mpslider.value = 50;
    }

    public void OnClickSPsliderdown()
    {
        spslider.value--;

    }

    public void OnClickMPsliderup()
    {
        mpslider.value++;

    }

}
