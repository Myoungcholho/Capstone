using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBox : MonoBehaviour
{
    public float speed;

    Rigidbody2D rigid;
    GameObject obj;
    Player_Action player;

    Vector3 past_pos;

    bool isReady;
    float boxMoveTime;

    private void Awake()
    {
        obj = GameObject.Find("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = obj.GetComponent<Player_Action>();
        isReady = false;
        past_pos = transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        

        

    }

    private void FixedUpdate()
    {
        if (isReady)
            moveObject();
        else
            resetPos();
    }

    void moveObject()
    {
        Debug.Log("moveObject() .. ");

        boxMoveTime += Time.deltaTime;
        switch (player.get_s_dir())
        {
            // 캐릭터가 왼쪽에서 박스를 밀었을 때 
            case Constants.DL:
                if (past_pos.x - 0.9f <= transform.position.x)
                {
                    if (boxMoveTime == 0.02f)
                        rigid.velocity = Vector2.left * speed;

                    if (0.5 < boxMoveTime)
                    {
                        boxMoveTime = 0;
                        isReady = false;
                    }
                }
                else
                {
                    rigid.velocity = Vector2.zero;

                    Vector3 temp = past_pos;
                    temp.x -= 1.0f;
                    transform.position = temp;
                    past_pos = transform.position;
                    boxMoveTime = 0;
                    isReady = false;
                }
                break;
            // 캐릭터가 왼쪽에서 박스를 밀었을 때 
            case Constants.DR:
                if (past_pos.x + 0.9f >= transform.position.x)
                {
                    if (boxMoveTime == 0.02f)
                        rigid.velocity = Vector2.right * speed;

                    if (0.5 < boxMoveTime)
                    {
                        boxMoveTime = 0;
                        isReady = false;
                    }
                }
                else
                {
                    rigid.velocity = Vector2.zero;

                    Vector3 temp = past_pos;
                    temp.x += 1.0f;
                    transform.position = temp;
                    past_pos = transform.position;
                    boxMoveTime = 0;
                    isReady = false;
                }
                break;
            // 캐릭터가 왼쪽에서 박스를 밀었을 때 
            case Constants.DD:
                if (past_pos.y - 0.9f <= transform.position.y)
                {
                    if (boxMoveTime == 0.02f)
                        rigid.velocity = Vector2.down * speed;

                    if (0.5 < boxMoveTime)
                    {
                        boxMoveTime = 0;
                        isReady = false;
                    }
                }
                else
                {
                    rigid.velocity = Vector2.zero;

                    Vector3 temp = past_pos;
                    temp.y -= 1.0f;
                    transform.position = temp;
                    past_pos = transform.position;
                    boxMoveTime = 0;
                    isReady = false;
                }
                break;
            // 캐릭터가 왼쪽에서 박스를 밀었을 때 
            case Constants.DU:
                if (past_pos.y + 0.9f >= transform.position.y)
                {
                    if (boxMoveTime == 0.02f)
                        rigid.velocity = Vector2.up * speed;

                    if (0.5 < boxMoveTime)
                    {   
                        boxMoveTime = 0;
                        isReady = false;
                    }
                }
                else
                {
                    rigid.velocity = Vector2.zero;

                    Vector3 temp = past_pos;
                    temp.y += 1.0f;
                    transform.position = temp;
                    past_pos = transform.position;
                    boxMoveTime = 0;
                    isReady = false;
                }
                break;

            default:
                Debug.Log(" 캐릭터 방향 없음 !! default ");
                break;
        }


        
    }

    void resetPos()
    {
        rigid.velocity = Vector2.zero;
        transform.position = past_pos;
    }

    public void setisReady(bool isReady)
    {
        this.isReady = isReady;
    }
}
