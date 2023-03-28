using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class gettest : MonoBehaviour
{
    //接続するURL
    //private string ID = SymbolManager.apimozaic;//ここを後ほどプルダウンでモザイクIDの種類を変えて代入設定する

    //ゲームオブジェクトUI > ButtonのInspector > On Click()から呼び出すメソッド
    public void OnClick()
    {
         //コルーチンを呼び出す
        StartCoroutine("OnSend", $"http://symbol-01.drugn.life:5900/mosaic-holder?mosaicId={SymbolManager.apimozaic}&addressType=2");

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
            //通信成功
            var hasAddress = JsonUtility.FromJson<HasMosaicAddress>(webRequest.downloadHandler.text);
            Debug.Log(hasAddress.address);
            SecondScene.ToAddress = hasAddress.address;
            Debug.Log(SecondScene.ToAddress);
            //Debug.Log(SymbolManager.apimozaic);
            //Debug.Log(ID);

        }
    }

    [System.Serializable]
    public class HasMosaicAddress
    {
        public string address;
    }

}