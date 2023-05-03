using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/* player 이동범위 
 *  x 축 -14 ~13
 *  y 축 -7~6
 */

public class Player_Action : MonoBehaviour
{
    public float speed;
    
    /* player 이동 관련 */
    float _x;
    float _y;
    float move_time;
    float min_x, max_x;
    float min_y, max_y;


    float h;
    float v;

    bool isHorizonMove;

    /* 값 가져오기 */
    Rigidbody2D rigid;

    /*애니메이션 */
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }


    // Update is called once per frame
    void Update()
    {
        /* <- 방향 Value -1 , -> 방향 Value 1 */
        h = Input.GetAxisRaw("Horizontal");
        /* 아래 방향 Value -1, 윗 방향 Value 1 */
        v = Input.GetAxisRaw("Vertical");

        if(h != 0)
        {
            Debug.Log("_h 값" + h);
        }

        if(v != 0)
        {
            Debug.Log("_v 값" + v);
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

        // 애니메이션
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
