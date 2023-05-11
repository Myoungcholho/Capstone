using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 방향 상수 값
static class Constants
{
    public const short DR = 1;
    public const short DL = 2;
    public const short DU = 3;
    public const short DD = 4;

}

public class Player_Action : MonoBehaviour
{
    public float speed;

    /*time */
    float h_subTime;
    float h_sumTime;
    float v_subTIme;
    float v_sumTime;

    /* player 이동 관련 */
    float _x;
    float _y;
    float move_time;
    float min_x, max_x;
    float min_y, max_y;

    // 캐릭터 방향
    short direction;
    Vector3 dirVec;
    Vector3 past_dir;
    bool isCharacterMove;

    // h : horizontal , v : vertical
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

    private void Start()
    {
        direction = Constants.DD;
        dirVec = Vector3.down;

        isCharacterMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        Player_Move();

    }

    void FixedUpdate()
    {
        if (isCharacterMove)
            return;

        Player_velocity();
    }

    void Player_Move()
    {
        if (isCharacterMove)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;

            anim.SetInteger("hRaw", 0);
            anim.SetInteger("vRaw", 0);

        }
        else
        {
            //rigid.constraints = RigidbodyConstraints2D.FreezeRotation;

            /* <- 방향 Value -1 , -> 방향 Value 1 */
            h = Input.GetAxisRaw("Horizontal");
            /* 아래 방향 Value -1, 윗 방향 Value 1 */
            v = Input.GetAxisRaw("Vertical");

            //체크
            if (h == -1 && v == -1)
            {
                Debug.Log("위 아래 동시 눌림");
            }

            bool hDown = Input.GetButtonDown("Horizontal");
            bool hUp = Input.GetButtonUp("Horizontal");
            bool vDown = Input.GetButtonDown("Vertical");
            bool vUp = Input.GetButtonUp("Vertical");

            // 방향전환 시점
            if (hDown)
            {
                isHorizonMove = true;

            }
            else if (vDown)
            {
                isHorizonMove = false;

            }
            else if (hUp || vUp)
            {
                isHorizonMove = h != 0;
            }

            // 애니메이션 [ h가 가로 !! v는 세로 !! ]
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
    }

    void Player_velocity()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        if(moveVec == Vector2.right)
        {
            direction = Constants.DR;
            dirVec = Vector3.right;
        }
        else if(moveVec == Vector2.left)
        {
            direction = Constants.DL;
            dirVec = Vector3.left;
        }
        else if(moveVec == Vector2.down)
        {
            direction = Constants.DD;
            dirVec = Vector3.down;
        }
        else if (moveVec == Vector2.up)
        {
            direction = Constants.DU;
            dirVec = Vector3.up;
        }

        rigid.velocity = moveVec * speed;
    }

    //캐릭터 방향 getter
    public short get_s_dir()
    {
        return direction;
    }

    public Vector3 get_v_dir()
    {
        return dirVec;
    }

    public void isCharacterSetter(bool isCharacter)
    {
        isCharacterMove = isCharacter;
    }

    // 충돌
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Box")
        {
            Debug.Log("박스와 충돌함 !! ");
            
        }
    }

}

