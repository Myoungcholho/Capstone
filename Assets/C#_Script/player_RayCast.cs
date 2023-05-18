using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_RayCast : MonoBehaviour
{

    Rigidbody2D rigid;
    Player_Action _pA;
    GameObject scanObject;
    bool canTransTo;
    float canTransTime;

    void Start()
    {
        canTransTo = false;
        canTransTime = 0f;
        rigid = GetComponent<Rigidbody2D>();
        _pA = GetComponent<Player_Action>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(rigid.position, _pA.get_v_dir() * 0.5f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, _pA.get_v_dir(), 0.5f, LayerMask.GetMask("Object"));
        if (rayHit.collider != null)
        {
            if (rayHit.collider.tag == "Box" && !canTransTo)
            {
                canTransTo = true;
                scanObject = rayHit.collider.gameObject;
                Debug.Log("��ĵ�� ������Ʈ �̸� : " + scanObject.name + "�Դϴ�.");
                //�ڽ� �����̴� �޼ҵ�
                scanObject.GetComponent<moveBox>().setisReady(true);

                //ĳ���� ������ �ᱸ�� �޼ҵ�
                _pA.isCharacterSetter(true);

            }
        }
    }
        
    private void FixedUpdate()
    {
        if (canTransTo)
        {
            canTransTime += Time.deltaTime;
            if (canTransTime >= 1f)
            {
                canTransTime = 0;
                canTransTo = false;
            }
        }



    }




}
