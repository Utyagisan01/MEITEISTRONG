using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class retry : MonoBehaviour
{

    public Text gameOverText;
    //�@gameOver���ɕ\������UI���
    [SerializeField]
    private GameObject gameoverUI;
    [SerializeField]
    private GameObject kakusiUI;
    [SerializeField]
    private GameObject purefab����;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
            gameOverText.text = "";
            //�@gameoverUI���A�N�e�B�u�ɂ���
            gameoverUI.SetActive(false);
            kakusiUI.SetActive(true);
            purefab����.SetActive(true);

    }


}


