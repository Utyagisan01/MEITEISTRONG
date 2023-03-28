using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counttext : MonoBehaviour
{
    public Text SP;
    public Text MP;
    public Button btn1;
    public Button btn2;
    int score = 50;
    int scoredown = 0;


    // Start is called before the first frame update
    void Start()
    {
         btn1.interactable = false;

    }

    void Update()
    {
        if (scoredown == 0)
        {
            btn1.interactable = false;
            btn2.interactable = true;

        }
        //SP.text = scoredown.ToString();
        //MP.text = score.ToString();

    }
    // -1点のボタンのOn Click()に登録
    public void OnClickSPdown()
    {
        if (scoredown > 0)
        {
            scoredown = scoredown - 1;
            SP.text = scoredown.ToString();
        }

    }

    // +1点のボタンのOn Click()に登録
    public void OnClickMPup()
    {
        if (score < 50)
        {
            score = score + 1;
            MP.text = score.ToString();
        }
    }

    // ResetのボタンのOn Click()に登録
    public void OnClickSPReset()
    {
        scoredown = 50;
        SP.text = scoredown.ToString();

        btn1.interactable = true;
        btn2.interactable = false;


    }

    // ResetのボタンのOn Click()に登録
    public void OnClickMPReset()
    {
        score = 0;
        MP.text = score.ToString();

    }



}