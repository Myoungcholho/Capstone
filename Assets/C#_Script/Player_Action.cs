using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ���� ��� ��
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
    
    /* player �̵� ���� */
    float _x;
    float _y;
    float move_time;
    float min_x, max_x;
    float min_y, max_y;

    // ĳ���� ����
    short direction;
    bool isCharacterMove;

    float h;
    float v;
    float old_h;
    float old_v;


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

            /* <- ���� Value -1 , -> ���� Value 1 */
            h = Input.GetAxisRaw("Horizontal");
            /* �Ʒ� ���� Value -1, �� ���� Value 1 */
            v = Input.GetAxisRaw("Vertical");

            if (old_h != h || old_v != v)
            {
                playerDirection();
            }

            bool hDown = Input.GetButtonDown("Horizontal");
            bool hUp = Input.GetButtonUp("Horizontal");
            bool vDown = Input.GetButtonDown("Vertical");
            bool vUp = Input.GetButtonUp("Vertical");

            // ������ȯ ����
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

            // �ִϸ��̼� [ h�� ���� !! v�� ���� !! ]
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
        // 1. ���ӿ����� �Ǵ¼��� �ð����� ����
        // 2. R �� ������ �� ���µǰ� , 
        // ---
        // 3. BestTime�� �������� ���� �� �ð��� ���� �ð����� �۴ٸ� ����
        // 4. Map�ڷᱸ���� Set
        // 5. bestTime�� ������ �ؽ�Ʈ�� ����

        

    }


    //ĳ���� ���� getter
    public short direction_getter()
    {
        return direction;
    }

    public void isCharacterSetter(bool isCharacter)
    {
        isCharacterMove = isCharacter;
    }

    // �浹
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Box")
        {
            Debug.Log("�ڽ��� �浹�� !! ");
            // �÷��̾ ��� ���߾�� ��.
        }
    }

}

