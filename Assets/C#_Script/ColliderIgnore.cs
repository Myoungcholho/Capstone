using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderIgnore : MonoBehaviour
{
    private void Awake()
    {
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GetComponentsInChildren<BoxCollider2D>()[1]);

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
