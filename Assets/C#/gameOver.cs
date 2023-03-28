using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "GameOver")
        {
            gameOverText.text = "GameOver";
            //�@gameoverUI���A�N�e�B�u�ɂ���
            gameoverUI.SetActive(true);
            kakusiUI.SetActive(false);
            purefab����.SetActive(false);

        }
    }

}


