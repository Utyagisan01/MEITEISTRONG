using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstScene : MonoBehaviour
{
    public Text TextFrame;
    public InputField inputField;
    //public InputField inputField2;//ここ

    // 最初のシーンでボタンに設置する関数
    public async void GetAmount()
    {
        SymbolManager.address = inputField.text;
        //SymbolManager.privatek = inputField2.text;//ここ
        Debug.Log(SymbolManager.address);
        //Debug.Log(SymbolManager.privatek);//ここ
        await SymbolManager.GetAmount();
        TextFrame.text = SymbolManager.amount.ToString(CultureInfo.InvariantCulture);
    }

    // 次のシーンで残高が取得されるか確認用
    public void SceneNext()
    {
        SceneManager.LoadScene("OP 1");
    }
}

