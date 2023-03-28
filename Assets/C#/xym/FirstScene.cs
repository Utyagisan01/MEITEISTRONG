using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstScene : MonoBehaviour
{
    public Text TextFrame;
    public InputField inputField;
    //public InputField inputField2;//����

    // �ŏ��̃V�[���Ń{�^���ɐݒu����֐�
    public async void GetAmount()
    {
        SymbolManager.address = inputField.text;
        //SymbolManager.privatek = inputField2.text;//����
        Debug.Log(SymbolManager.address);
        //Debug.Log(SymbolManager.privatek);//����
        await SymbolManager.GetAmount();
        TextFrame.text = SymbolManager.amount.ToString(CultureInfo.InvariantCulture);
    }

    // ���̃V�[���Ŏc�����擾����邩�m�F�p
    public void SceneNext()
    {
        SceneManager.LoadScene("OP 1");
    }
}

