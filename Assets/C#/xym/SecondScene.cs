using System;
using System.Globalization;
using NativeWebSocket;
using UnityEngine;
using UnityEngine.UI;

public class SecondScene : MonoBehaviour
{
    // �\���p
    //�����ŃA�h���X�ۊ�

    [SerializeField] private Text amount;

    // ���M�e�X�g�p
    public static string ToAddress { get; set; }//�����ɂ��ꂽ��SymbolManager.toaddress
    public string ToMosaicId;
    public string Message;
    public string SendAmount;

    // �G�f�B�^�e�X�g�p webGl�r���h�̏ꍇ�͕s�v
    public string PrivateKey;//�����ɂ��ꂽ��SymbolManager.PrivateKey

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
            await SymbolManager.TransferTransaction(PrivateKey, ToAddress, ToMosaicId,//�����ɂ��ꂽ��SymbolManager.toaddress��SymbolManager.privatek
            ulong.Parse(SendAmount), Message, ObserveTransaction);
#endif
    }

    // �����g�����U�N�V���������F���ꂽ��c�����X�V����֐�
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