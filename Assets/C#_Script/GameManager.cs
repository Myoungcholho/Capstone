using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    private bool isGameover;
    private int SceneNum;

    // Start is called before the first frame update
    void Start()
    {
        isGameover = false;
        SceneNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // ���ӿ����� �ƴ� ����
        if(!isGameover)
        {
            // R Ű�� ������ ��� �� �����
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneNum);
            }


        }
        else
        {

        }
    }

    // ���ӿ����� ��� Manager EndGame ȣ��
    public void EndGame()
    {
        isGameover = true;

    }
}
