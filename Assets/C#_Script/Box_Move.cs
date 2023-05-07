using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Move : MonoBehaviour
{
    Rigidbody2D box_rigidbody;
    float speed;
    bool player_collision;
    Vector3 objecttransform;
    float boxMoveTime;

    //player
    GameObject obj;
    Player_Action player;

    private void Awake()
    {
        box_rigidbody = GetComponent<Rigidbody2D>();        
    }

    // Start is called before the first frame update
    void Start()
    {
        player_collision = false;
        objecttransform = transform.position;
        obj = GameObject.Find("Player");
        player = obj.GetComponent<Player_Action>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    // 0.02초
    private void FixedUpdate()
    {

        //충돌 시 
        if(player_collision)
        {
            boxMoveTime += Time.deltaTime;
            switch(player.direction_getter())
            {
                // 캐릭터가 오른쪽에서 박스를 밀었을 때
                case Constants.DL:
                    if (objecttransform.x - 0.9f <= transform.position.x )
                    {
                        box_rigidbody.velocity = Vector2.left * 2;
                        player.isCharacterSetter(true);

                        if(0.5 < boxMoveTime)
                        {
                            player_collision = false;
                            player.isCharacterSetter(false);
                            boxMoveTime = 0;
                        }

                    }
                    else
                    {
                        box_rigidbody.velocity = Vector2.zero;

                        Vector3 temp = objecttransform;
                        temp.x -= 1.0f;
                        transform.position = temp;
                        objecttransform = transform.position;

                        Debug.Log("박스 이동 시간 " + boxMoveTime);
                        boxMoveTime = 0;

                        player_collision = false;
                        player.isCharacterSetter(false);
                    }
                    break;
                // 캐릭터가 왼쪽에서 박스를 밀었을 때 
                case Constants.DR:
                    if (objecttransform.x + 0.9 >= transform.position.x)
                    {
                        box_rigidbody.velocity = Vector2.right * 2;
                        player.isCharacterSetter(true);

                        if (0.5 < boxMoveTime)
                        {
                            player_collision = false;
                            player.isCharacterSetter(false);
                            boxMoveTime = 0;
                        }

                    }
                    else
                    {
                        box_rigidbody.velocity = Vector2.zero;

                        Vector3 temp = objecttransform;
                        temp.x += 1.0f;
                        transform.position = temp;
                        objecttransform = transform.position;

                        Debug.Log("박스 이동 시간 " + boxMoveTime);
                        boxMoveTime = 0;


                        player_collision = false;
                        player.isCharacterSetter(false);
                    }
                    break;
                // 캐릭터가 위에서 박스를 밀었을 때
                case Constants.DD:
                    if (objecttransform.y - 0.9f <= transform.position.y)
                    {
                        box_rigidbody.velocity = Vector2.down * 2;
                        player.isCharacterSetter(true);

                        if (0.5 < boxMoveTime)
                        {
                            player_collision = false;
                            player.isCharacterSetter(false);
                            boxMoveTime = 0;
                        }

                    }
                    else
                    {
                        box_rigidbody.velocity = Vector2.zero;

                        Vector3 temp = objecttransform;
                        temp.y -= 1.0f;
                        transform.position = temp;
                        objecttransform = transform.position;

                        Debug.Log("박스 이동 시간 " + boxMoveTime);
                        boxMoveTime = 0;

                        player_collision = false;
                        player.isCharacterSetter(false);
                    }
                    break;
                // 캐릭터가 아래에서 박스를 밀었을 때
                case Constants.DU:
                    if (objecttransform.y + 0.9f >= transform.position.y)
                    {
                        box_rigidbody.velocity = Vector2.up * 2;
                        player.isCharacterSetter(true);

                        if (0.5 < boxMoveTime)
                        {
                            player_collision = false;
                            player.isCharacterSetter(false);
                            boxMoveTime = 0;
                        }

                    }
                    else
                    {
                        box_rigidbody.velocity = Vector2.zero;

                        Vector3 temp = objecttransform;
                        temp.y += 1.0f;
                        transform.position = temp;
                        objecttransform = transform.position;

                        Debug.Log("박스 이동 시간 " + boxMoveTime);
                        boxMoveTime = 0;

                        player_collision = false;
                        player.isCharacterSetter(false);
                    }
                    break;
                default:

                    break;
            }
        }

    }

    // 충돌
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Player와 충돌함 !! ");

            if (collision.collider.tag == "Wall")
            {
                Debug.Log("Wall 충돌함 !! ");

                player_collision = false;
                return;
            }


            player_collision = true;
        }

        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
            
    }

    // 메소드
    


}
