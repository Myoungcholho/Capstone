using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapPotal : MonoBehaviour
{
    public string transferMapName;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Æ÷Å» Trigger ¶¹½À´Ï´Ù.");
        if(collision.gameObject.name == "Player")
        {
            gameManager.currentMapName = transferMapName;
            SceneManager.LoadScene(transferMapName);
        }
    }
}
