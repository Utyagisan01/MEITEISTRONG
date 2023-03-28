using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mozaicidkakunou : MonoBehaviour
{
    public string ID1;
    public string ID2;
    public string ID3;
    public string ID4;
    public string ID5;

    public void OnClickID1()
    {
        SymbolManager.apimozaic = ID1;
        Debug.Log(SymbolManager.apimozaic);
    }

    public void OnClickID2()
    {
        SymbolManager.apimozaic = ID2;
        Debug.Log(SymbolManager.apimozaic);
    }

    public void OnClickID3()
    {
        SymbolManager.apimozaic = ID3;
        Debug.Log(SymbolManager.apimozaic);
    }

    public void OnClickID4()
    {
        SymbolManager.apimozaic = ID4;
        Debug.Log(SymbolManager.apimozaic);
    }

    public void OnClickID5()
    {
        SymbolManager.apimozaic = ID5;
        Debug.Log(SymbolManager.apimozaic);
    }

}

