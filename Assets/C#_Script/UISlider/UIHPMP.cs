using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHPMP : MonoBehaviour
{
    [HideInInspector]
    public PlayerStates playerStates;
    
    [SerializeField]
    private Slider sliderHP;
    [SerializeField]
    private Text textHP;
    [SerializeField]
    private Slider sliderMP;
    [SerializeField]
    private Text textMP;

    private void Start()
    {
        playerStates = GameObject.Find("Player").GetComponent<PlayerStates>();
        if (playerStates == null)
            Debug.Log("UIHPMP.cs에서 playerStates.cs 가져오지 못함.");

    }

    // Update is called once per frame
    void Update()
    {
        if (sliderHP != null)
        {
            sliderHP.value = Utils.Percent(playerStates.HP, playerStates.HPMax);
        }
        if (textHP != null)
        {
            textHP.text = playerStates.HP + "/" + playerStates.HPMax;
        }
    }

    public void SetupStateUI()
    {
        
    }
    
}
