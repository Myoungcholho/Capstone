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
        // 게임오버가 아닌 동안
        if(!isGameover)
        {
            // R 키를 눌렀을 경우 맵 재시작
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneNum);
            }


        }
        else
        {

        }
    }

    // 게임오버인 경우 Manager EndGame 호출
    public void EndGame()
    {
        isGameover = true;

    }
}
