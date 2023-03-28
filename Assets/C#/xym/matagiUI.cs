using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class matagiUI : MonoBehaviour
{
    [SerializeField]
    private GameObject UI1;
    [SerializeField]
    private GameObject UI2;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void OnClick()
    {
        UI1.SetActive(false);
        UI2.SetActive(true);

    }

    public void OnClick2()
    {
        UI2.SetActive(false);

    }

}