using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    //���� �� ����
    public string currentMapName;


    //�κ��丮
    public GameObject inventoryPanel;
    bool activeInventory = false;

    //���������
    private bool isGameover;
    private int SceneNum;
    

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        isGameover = false;
        SceneNum = 0;
        inventoryPanel.SetActive(activeInventory);
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
            // I Ű�� ������ �� �κ��丮
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

    // ���ӿ����� ��� Manager EndGame ȣ��
    public void EndGame()
    {
        isGameover = true;

    }
}
