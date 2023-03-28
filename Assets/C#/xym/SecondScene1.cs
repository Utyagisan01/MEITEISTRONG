using System;
using System.Globalization;
using NativeWebSocket;
using UnityEngine;
using UnityEngine.UI;

public class SecondScene1 : MonoBehaviour
{

    // ���M�e�X�g�p
    public string ToAddress;
    public string ToMosaicId;
    public string Message;
    public string SendAmount;

    // �G�f�B�^�e�X�g�p webGl�r���h�̏ꍇ�͕s�v
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
            await SymbolManager.TransferTransaction(PrivateKey.text, ToAddress, ToMosaicId,//�����ɂ��ꂽ��SymbolManager.toaddress��SymbolManager.privatek
            ulong.Parse(SendAmount), Message);
#endif
    }


}