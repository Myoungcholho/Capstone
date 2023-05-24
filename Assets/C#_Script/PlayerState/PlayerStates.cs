using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    private MyStates states;

    public float HP
    {
        set => states.HP = Mathf.Clamp(value, 0, states.HPMax);
        get => states.HP;
    }

    public float MP
    {
        set => states.MP = Mathf.Clamp(value, 0, states.MPMax);
        get => states.MP;
    }

    public float HPMax
    {
        set => states.HPMax = value;
        get => states.HPMax;
    }

    public float MPMax
    {
        set => states.MPMax = value;
        get => states.MPMax;
    }

    void Start()
    {
        MPMax = 10f;
        HPMax = 10f;
        HP = 10f;
        MP = 10f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[System.Serializable]
public struct MyStates
{
    [HideInInspector]
    public float HP;
    [HideInInspector]
    public float HPMax;
    [HideInInspector]
    public float MP;
    [HideInInspector]
    public float MPMax;
}