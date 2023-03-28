using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setumei : MonoBehaviour
{

    [SerializeField]
    private GameObject setumeiUI;
    [SerializeField]
    private GameObject NextUI;
    [SerializeField]
    private GameObject purefab生成;
    [SerializeField]
    private GameObject sucorcount;


    // Start is called before the first frame update
    void Start()
    {
        purefab生成.SetActive(false);
        sucorcount.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {

            setumeiUI.SetActive(false);
            NextUI.SetActive(true);
            purefab生成.SetActive(true);
            sucorcount.SetActive(true);
    }

}


