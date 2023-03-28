using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class gettest : MonoBehaviour
{
    //�ڑ�����URL
    //private string ID = SymbolManager.apimozaic;//��������قǃv���_�E���Ń��U�C�NID�̎�ނ�ς��đ���ݒ肷��

    //�Q�[���I�u�W�F�N�gUI > Button��Inspector > On Click()����Ăяo�����\�b�h
    public void OnClick()
    {
         //�R���[�`�����Ăяo��
        StartCoroutine("OnSend", $"http://symbol-01.drugn.life:5900/mosaic-holder?mosaicId={SymbolManager.apimozaic}&addressType=2");

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
            //�ʐM����
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