using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/* player �̵����� 
 *  x �� -14 ~13
 *  y �� -7~6
 */

public class Player_Action : MonoBehaviour
{
    public float speed;
    
    /* player �̵� ���� */
    float _x;
    float _y;
    float move_time;
    float min_x, max_x;
    float min_y, max_y;


    float h;
    float v;

    bool isHorizonMove;

    /* �� �������� */
    Rigidbody2D rigid;

    /*�ִϸ��̼� */
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }


    // Update is called once per frame
    void Update()
    {
        /* <- ���� Value -1 , -> ���� Value 1 */
        h = Input.GetAxisRaw("Horizontal");
        /* �Ʒ� ���� Value -1, �� ���� Value 1 */
        v = Input.GetAxisRaw("Vertical");

        if(h != 0)
        {
            Debug.Log("_h ��" + h);
        }

        if(v != 0)
        {
            Debug.Log("_v ��" + v);
        }

        bool hDown = Input.GetButtonDown("Horizontal");
        bool hUp =  Input.GetButtonUp("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool vUp = Input.GetButtonUp("Vertical");

        if (hDown || vUp)
            isHorizonMove = true;
        else if (vDown || hUp)
            isHorizonMove = false;
        else if (hUp || vUp)
        {
            isHorizonMove = h != 0;
        }

        // �ִϸ��̼�
        if (anim.GetInteger("hRaw") != h)
        {
            anim.SetBool("isMoveDirection", true);
            anim.SetInteger("hRaw", (int)h);
        }
        else if (anim.GetInteger("vRaw") != v)
        {
            anim.SetBool("isMoveDirection", true);
            anim.SetInteger("vRaw", (int)v);
        }
        else
        {
            anim.SetBool("isMoveDirection", false);
        }


    }

    void FixedUpdate()
    {
        Player_Move();
    }

    void Player_Move()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;
    }


}
