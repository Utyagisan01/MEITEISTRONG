using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using AOT;
using CatSdk.CryptoTypes;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using CatSdk.Facade;
using CatSdk.Symbol;
using CatSdk.Symbol.Factory;
using CatSdk.Utils;
using UnityEngine.Events;
using Network = CatSdk.Symbol.Network;
using NetworkTimestamp = CatSdk.Symbol.NetworkTimestamp;

public class SymbolManager
{
    // �ȉ��̃f�[�^�͑��̃V�[���Ȃǂł����p�ł���
    public static string address { get; set; }
    public static float amount { get; set; }
    //public static string toaddress { get; set; }//����
    public static string apimozaic { get; set; }//�����܂������O
    //public static string privatek { get; set; }//����

    public static readonly string xymId = "6BED913FA20223F8";//testnet�̏ꍇ72C0212E67A08BCE
    public const string Node = "https://ik1-432-48199.vs.sakura.ne.jp:3001";//testnet�̏ꍇhttps://mikun-testnet.tk:3001
    public static readonly string WsNode = "wss://ik1-432-48199.vs.sakura.ne.jp:3001/ws";//testnet�̏ꍇwss://mikun-testnet.tk:3001/ws
    public static readonly Network network = Network.MainNet;//TestNet�̏ꍇTestNet
    public static readonly SymbolFacade facade = new(network);

    // ���̊֐����{�^���ɃC���X�y�N�^�[����ݒ肷��
    public static async UniTask GetAmount()
    {
        Debug.Log($"{Node}/accounts/{address}");
        var symbolAccountData = await GetData($"{Node}/accounts/{address}");
        var symbolAccountDataJson = JsonUtility.FromJson<Root>(symbolAccountData);
        var xym = symbolAccountDataJson?.account.mosaics.FirstOrDefault(mosaic => mosaic.id == xymId);
        if (xym != null) amount = (float)xym.amount / 1000000;
    }

    // Api����f�[�^�擾���邽�߂̔ėp�I�Ȋ֐�
    static async UniTask<string> GetData(string url)
    {
        using var webRequest = UnityWebRequest.Get(url);
        await webRequest.SendWebRequest();
        if (webRequest.result == UnityWebRequest.Result.ConnectionError) throw new Exception(webRequest.error);
        return webRequest.downloadHandler.text;
    }

    // �]���g�����U�N�V�������M Editor�p
    public static async UniTask TransferTransaction(string _priavteKey, string _address, string _mosaicId, ulong _amount, string _message, UnityAction function = null)
    {
        var privateKey = new PrivateKey(_priavteKey);
        var keyPair = new KeyPair(privateKey);
        var tx = BuildTransferTransaction(_address, Converter.BytesToHex(keyPair.PublicKey.bytes), _mosaicId, _amount, _message);
        var signature = facade.SignTransaction(keyPair, tx);
        var payload = TransactionsFactory.AttachSignature(tx, signature);
        const string endpoint = Node + "/transactions";
        var result = await Announce(endpoint, payload);
        Debug.Log(result);
        var hash = facade.HashTransaction(tx);
        WebSocketManager.ConnectWebSocket(WsNode, _address, Converter.BytesToHex(hash.bytes));
        WebSocketManager.OnConfirmedTransaction += function;
    }

    // �]���g�����U�N�V�������M SSS�p
    public static async UniTask TransferTransaction(string _address, string _mosaicId, ulong _amount, string _message, UnityAction function = null)
    {
        var pubKey = SSS.getActivePublicKey();
        var tx = BuildTransferTransaction(_address, pubKey, _mosaicId, _amount, _message);
        var signedPayload = await SSS.SignTransactionByPayloadAsync(Converter.BytesToHex(tx.Serialize()));
        var arr = signedPayload.Split(",");
        var payload = "{ \"payload\" : \"" + arr[0] + "\"}";
        const string endpoint = Node + "/transactions";
        var result = await Announce(endpoint, payload);
        Debug.Log(result);
        WebSocketManager.ConnectWebSocket(WsNode, _address, arr[1]);
        WebSocketManager.OnConfirmedTransaction += function;
    }

    private static TransferTransactionV1 BuildTransferTransaction(string _address, string _pubKey, string _mosaicId, ulong _amount, string _message, ulong _feeMultiplier = 100)
    {
        var publicKey = new PublicKey(Converter.HexToBytes(_pubKey));

        var tx = new TransferTransactionV1
        {
            Network = NetworkType.MAINNET,
            RecipientAddress = new UnresolvedAddress(Converter.StringToAddress(_address)),
            Mosaics = new UnresolvedMosaic[]
            {
                new()
                {
                    MosaicId = new UnresolvedMosaicId(ulong.Parse(_mosaicId, NumberStyles.HexNumber)),
                    Amount = new Amount(_amount)
                },
            },
            SignerPublicKey = publicKey,
            Message = Converter.Utf8ToPlainMessage(_message),
            Deadline = new Timestamp(facade.Network.FromDatetime<NetworkTimestamp>(DateTime.UtcNow).AddHours(2).Timestamp)
        };
        tx.Fee = new Amount(tx.Size * _feeMultiplier);
        return tx;
    }

    private static async UniTask<string> Announce(string endpoint, string payload)
    {
        using var webRequest = UnityWebRequest.Put(endpoint, Encoding.UTF8.GetBytes(payload));
        webRequest.SetRequestHeader("Content-Type", "application/json");
        await webRequest.SendWebRequest();
        if (webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            throw new Exception(webRequest.error);
        }
        return webRequest.downloadHandler.text;
    }

    [System.Serializable]
    public class SupplementalPublicKeys
    {
    }

    [System.Serializable]
    public class ActivityBucket
    {
        public string startHeight;
        public string totalFeesPaid;
        public int beneficiaryCount;
        public string rawScore;
    }

    [System.Serializable]
    public class Mosaic
    {
        public string id;
        public ulong amount;
    }
    [System.Serializable]
    public class Account
    {
        public int version;
        public string address;
        public string addressHeight;
        public string publicKey;
        public string publicKeyHeight;
        public int accountType;
        public SupplementalPublicKeys supplementalPublicKeys;
        public List<ActivityBucket> activityBuckets;
        public List<Mosaic> mosaics;
        public string importance;
        public string importanceHeight;
    }

    [System.Serializable]
    public class Root
    {
        public Account account;
        public string id;
    }
}

public static class SSS
{
    [DllImport("__Internal")]
    public static extern string getActivePublicKey();

    [DllImport("__Internal")]
    private static extern string signTransactionByPayload(Action<string> cb, string pyaload);

    private static UniTaskCompletionSource<string> utcs;

    [MonoPInvokeCallback(typeof(Action<string>))]
    private static void funcCB(string payload)
    {
        utcs.TrySetResult(payload);
    }

    public static UniTask<string> SignTransactionByPayloadAsync(string payload)
    {
        utcs = new UniTaskCompletionSource<string>();
        signTransactionByPayload(funcCB, payload);
        return utcs.Task;
    }
}