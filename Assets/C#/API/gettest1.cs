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


    //true�A�N�e�B�u,false��A�N�e�B�u
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



    //�Q�[���I�u�W�F�N�gUI > Button��Inspector > On Click()����Ăяo�����\�b�h
    public void checadressID1()
    {
         //�R���[�`�����Ăяo��
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
        //�R���[�`�����Ăяo��
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
        //�R���[�`�����Ăяo��
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
        //�R���[�`�����Ăяo��
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


    //�Q�[���I�u�W�F�N�gUI > Button��Inspector > On Click()����Ăяo�����\�b�h
    public void checadressID5()
    {
        //�R���[�`�����Ăяo��
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



    //�R���[�`��
    IEnumerator OnSend(string url)
    {
        //URL��GET�ŗp��
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        //URL�ɐڑ����Č��ʂ��߂��Ă���܂őҋ@
        yield return webRequest.SendWebRequest();

        //�G���[���o�Ă��Ȃ����`�F�b�N
        if (webRequest.isNetworkError)
        {
            //�ʐM���s
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


