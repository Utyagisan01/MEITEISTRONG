using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections.Generic;

public class gettest1 : MonoBehaviour
{
    [SerializeField]
    private GameObject UI1;
    [SerializeField]
    private GameObject UI2;

    [SerializeField]
    private GameObject button1;
    [SerializeField]
    private GameObject button2;
    [SerializeField]
    private GameObject button3;
    [SerializeField]
    private GameObject button4;

    [SerializeField]
    private GameObject sankaku1;
    [SerializeField]
    private GameObject sankaku2;
    [SerializeField]
    private GameObject sankaku3;
    [SerializeField]
    private GameObject sankaku4;
    [SerializeField]
    private GameObject sankaku5;
    [SerializeField]
    private GameObject sankaku6;
    [SerializeField]
    private GameObject sankaku7;


    public string ID1;
    public string ID2;
    public string ID3;
    public string ID4;
    public string ID5;
    public Text text;


    //trueアクティブ,false非アクティブ
    public void UIchengi()
    {
        UI1.SetActive(false);
        UI2.SetActive(true);
        sankaku6.SetActive(false);
        sankaku1.SetActive(true);

    }

    public void UImodoru()
    {
        text.text = "";
        UI2.SetActive(false);
        UI1.SetActive(true);
        sankaku6.SetActive(true);
        sankaku1.SetActive(false);
        sankaku2.SetActive(false);
        sankaku3.SetActive(false);
        sankaku4.SetActive(false);
        sankaku5.SetActive(false);
        sankaku7.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);

    }

    public void sankaku()
    {
        sankaku1.SetActive(false);
        sankaku2.SetActive(false);
        sankaku3.SetActive(false);
        sankaku4.SetActive(false);
        sankaku5.SetActive(false);
        sankaku6.SetActive(false);
        sankaku7.SetActive(true);

    }



    //ゲームオブジェクトUI > ButtonのInspector > On Click()から呼び出すメソッド
    public void checadressID1()
    {
         //コルーチンを呼び出す
        StartCoroutine("OnSend", $"http://symbol-01.drugn.life:5900/mosaic-holder/list?mosaicId={ID1}&addressType=2");
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);

        sankaku1.SetActive(true);
        sankaku2.SetActive(false);
        sankaku3.SetActive(false);
        sankaku4.SetActive(false);
        sankaku5.SetActive(false);
        sankaku6.SetActive(false);
        sankaku7.SetActive(false);

    }

    public void checadressID2()
    {
        //コルーチンを呼び出す
        StartCoroutine("OnSend", $"http://symbol-01.drugn.life:5900/mosaic-holder/list?mosaicId={ID2}&addressType=2");
        button1.SetActive(true);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);

        sankaku1.SetActive(false);
        sankaku2.SetActive(true);
        sankaku3.SetActive(false);
        sankaku4.SetActive(false);
        sankaku5.SetActive(false);
        sankaku6.SetActive(false);
        sankaku7.SetActive(false);

    }

    public void checadressID3()
    {
        //コルーチンを呼び出す
        StartCoroutine("OnSend", $"http://symbol-01.drugn.life:5900/mosaic-holder/list?mosaicId={ID3}&addressType=2");
        button1.SetActive(false);
        button2.SetActive(true);
        button3.SetActive(false);
        button4.SetActive(false);

        sankaku1.SetActive(false);
        sankaku2.SetActive(false);
        sankaku3.SetActive(true);
        sankaku4.SetActive(false);
        sankaku5.SetActive(false);
        sankaku6.SetActive(false);
        sankaku7.SetActive(false);

    }

    public void checadressID4()
    {
        //コルーチンを呼び出す
        StartCoroutine("OnSend", $"http://symbol-01.drugn.life:5900/mosaic-holder/list?mosaicId={ID4}&addressType=2");
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(true);
        button4.SetActive(false);

        sankaku1.SetActive(false);
        sankaku2.SetActive(false);
        sankaku3.SetActive(false);
        sankaku4.SetActive(true);
        sankaku5.SetActive(false);
        sankaku6.SetActive(false);
        sankaku7.SetActive(false);

    }


    //ゲームオブジェクトUI > ButtonのInspector > On Click()から呼び出すメソッド
    public void checadressID5()
    {
        //コルーチンを呼び出す
        StartCoroutine("OnSend", $"http://symbol-01.drugn.life:5900/mosaic-holder/list?mosaicId={ID5}&addressType=2");
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(true);

        sankaku1.SetActive(false);
        sankaku2.SetActive(false);
        sankaku3.SetActive(false);
        sankaku4.SetActive(false);
        sankaku5.SetActive(true);
        sankaku6.SetActive(false);
        sankaku7.SetActive(false);

    }



    //コルーチン
    IEnumerator OnSend(string url)
    {
        //URLをGETで用意
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        //URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();

        //エラーが出ていないかチェック
        if (webRequest.isNetworkError)
        {
            //通信失敗
            Debug.Log(webRequest.error);
        }
        else
        {
            var hasAddresses = JsonUtility.FromJson<HasMosaicAddress>(webRequest.downloadHandler.text);
            text.text = "";
            foreach (var address in hasAddresses.addresses)
            {
                Debug.Log(address);
                text.text += address + "\n";

            }
        }

    }


    [System.Serializable]
    public class HasMosaicAddress
    {
        public List<string> addresses;
    }

}


