using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class henzuitimer : MonoBehaviour
{
    private float step_time;    // �o�ߎ��ԃJ�E���g�p

    // Start is called before the first frame update
    void Start()
    {
        step_time = 0.0f;       // �o�ߎ��ԏ�����
    }

    // Update is called once per frame
    void Update()
    {
        // �o�ߎ��Ԃ��J�E���g
        step_time += Time.deltaTime;

        // 3�b��ɉ�ʑJ�ځiscene2�ֈړ��j
        if (step_time >= 85.0f)
        {
            SceneManager.LoadScene("OP 1");
        }

    }
}
