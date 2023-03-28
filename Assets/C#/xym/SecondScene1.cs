using System;
using System.Globalization;
using NativeWebSocket;
using UnityEngine;
using UnityEngine.UI;

public class SecondScene1 : MonoBehaviour
{

    // 送信テスト用
    public string ToAddress;
    public string ToMosaicId;
    public string Message;
    public string SendAmount;

    // エディタテスト用 webGlビルドの場合は不要
    public InputField PrivateKey;

    private void Start()
    {
        Debug.Log(ToAddress);

    }

    public async void SendTransaction()
    {

#if UNITY_WEBGL && !UNITY_EDITOR
        await SymbolManager.TransferTransaction(ToAddress, ToMosaicId,
            ulong.Parse(SendAmount), Message);
#else
            await SymbolManager.TransferTransaction(PrivateKey.text, ToAddress, ToMosaicId,//ここにいれたいSymbolManager.toaddressとSymbolManager.privatek
            ulong.Parse(SendAmount), Message);
#endif
    }


}