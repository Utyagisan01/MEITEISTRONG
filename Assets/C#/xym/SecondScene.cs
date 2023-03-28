using System;
using System.Globalization;
using NativeWebSocket;
using UnityEngine;
using UnityEngine.UI;

public class SecondScene : MonoBehaviour
{
    // 表示用
    //ここでアドレス保管

    [SerializeField] private Text amount;

    // 送信テスト用
    public static string ToAddress { get; set; }//ここにいれたいSymbolManager.toaddress
    public string ToMosaicId;
    public string Message;
    public string SendAmount;

    // エディタテスト用 webGlビルドの場合は不要
    public string PrivateKey;//ここにいれたいSymbolManager.PrivateKey

    private void Start()
    {
        Debug.Log(ToAddress);
        amount.text = SymbolManager.amount.ToString(CultureInfo.InvariantCulture);
        //string ToAddress = SymbolManager.toaddress;

    }

    public async void SendTransaction()
    {

#if UNITY_WEBGL && !UNITY_EDITOR
        await SymbolManager.TransferTransaction(ToAddress, ToMosaicId,
            ulong.Parse(SendAmount), Message, ObserveTransaction);
#else
            await SymbolManager.TransferTransaction(PrivateKey, ToAddress, ToMosaicId,//ここにいれたいSymbolManager.toaddressとSymbolManager.privatek
            ulong.Parse(SendAmount), Message, ObserveTransaction);
#endif
    }

    // 送金トランザクションが承認されたら残高を更新する関数
    private async void ObserveTransaction()
    {
        Debug.Log($"Complete Transaction");
        await SymbolManager.GetAmount();
        amount.text = SymbolManager.amount.ToString(CultureInfo.InvariantCulture);
        WebSocketManager.OnConfirmedTransaction -= ObserveTransaction;


    }

    private void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        WebSocketManager.websocket?.DispatchMessageQueue();
#endif
    }

    private async void OnDestroy()
    {
        if (WebSocketManager.websocket == null) return;
        if (WebSocketManager.websocket.State != WebSocketState.Closed && WebSocketManager.websocket.State != WebSocketState.Closing) await WebSocketManager.websocket.Close();
    }

    private async void OnApplicationQuit()
    {
        if (WebSocketManager.websocket == null) return;
        if (WebSocketManager.websocket.State != WebSocketState.Closed && WebSocketManager.websocket.State != WebSocketState.Closing) await WebSocketManager.websocket.Close();
    }
}