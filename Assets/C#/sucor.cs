using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sucor : MonoBehaviour
{
    public Text sucorText;
    private int scorecount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
 
            scorecount = scorecount + 1;
            sucorText.text = scorecount.ToString();

        }
    }

    // Reset�̃{�^����On Click()�ɓo�^
    public void OnClickReset()
    {
        scorecount = 0;
        sucorText.text = scorecount.ToString();

    }

    public void OnClicksousin()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(scorecount);
    }

}
