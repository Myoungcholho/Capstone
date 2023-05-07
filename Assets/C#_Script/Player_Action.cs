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
    
    /* player 이동 관련 */
    float _x;
    float _y;
    float move_time;
    float min_x, max_x;
    float min_y, max_y;

    // 캐릭터 방향
    short direction;
    bool isCharacterMove;

    float h;
    float v;
    float old_h;
    float old_v;


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
        isCharacterMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCharacterMove)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePosition;
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;

            anim.SetInteger("hRaw", 0);
            anim.SetInteger("vRaw", 0);

        }
        else
        {
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;

            /* <- 방향 Value -1 , -> 방향 Value 1 */
            h = Input.GetAxisRaw("Horizontal");
            /* 아래 방향 Value -1, 윗 방향 Value 1 */
            v = Input.GetAxisRaw("Vertical");

            if (old_h != h || old_v != v)
            {
                playerDirection();
            }

            bool hDown = Input.GetButtonDown("Horizontal");
            bool hUp = Input.GetButtonUp("Horizontal");
            bool vDown = Input.GetButtonDown("Vertical");
            bool vUp = Input.GetButtonUp("Vertical");

            // 방향전환 시점
            if (hDown || vUp)
            {
                isHorizonMove = true;

            }
            else if (vDown || hUp)
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

    void FixedUpdate()
    {
        if (isCharacterMove)
            return;

        Player_Move();
    }

    void Player_Move()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;
    }

    void playerDirection()
    {
        old_h = h;
        old_v = v;

        if (old_h == -1)
            direction = Constants.DL;
        else if (old_h == 1)
            direction = Constants.DR;
        else if (old_v == -1)
            direction = Constants.DD;
        else if (old_v == 1)
            direction = Constants.DU;
    }

    public void EndGame()
    {
        // 1. 게임오버가 되는순간 시간누적 중지
        // 2. R 로 눌렀을 때 리셋되게 , 
        // ---
        // 3. BestTime을 가져오고 만약 그 시간이 측정 시간보다 작다면 갱신
        // 4. Map자료구조에 Set
        // 5. bestTime을 가져와 텍스트에 셋팅

        

    }


    //캐릭터 방향 getter
    public short direction_getter()
    {
        return direction;
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
            // 플레이어가 잠시 멈추어야 함.
        }
    }

}

