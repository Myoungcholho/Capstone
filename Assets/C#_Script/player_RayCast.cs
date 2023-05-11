using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_RayCast : MonoBehaviour
{

    Rigidbody2D rigid;
    Player_Action _pA;
    GameObject scanObject;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        _pA = GetComponent<Player_Action>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
        
    private void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, _pA.get_v_dir(), new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, _pA.get_v_dir(), 1.0f, LayerMask.GetMask("Object"));

        if(rayHit.collider.tag == "Box")
        {
            scanObject = rayHit.collider.gameObject;
            Debug.Log("스캔된 오브젝트 이름 : " + scanObject.name + "입니다.");
            scanObject.GetComponent<moveBox>().setisReady(true);
        }

        
        


    }




}
