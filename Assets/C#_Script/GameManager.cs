using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //인벤토리
    public GameObject inventoryPanel;
    bool activeInventory = false;

    //게임재시작
    private bool isGameover;
    private int SceneNum;
    

    void Start()
    {
        isGameover = false;
        SceneNum = 0;
        inventoryPanel.SetActive(activeInventory);
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
            // I 키를 눌렀을 때 인벤토리
            if(Input.GetKeyDown(KeyCode.I))
            {
                activeInventory = !activeInventory;
                inventoryPanel.SetActive(activeInventory);
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
