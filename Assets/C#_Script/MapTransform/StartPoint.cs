using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint;

    private GameManager gameManager;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        player = GameObject.Find("Player");
        if(startPoint == gameManager.currentMapName)
        {
            player.transform.position = this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
