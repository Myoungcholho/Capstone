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
        obj = GameObject.Find("Player");
        box_rigidbody = GetComponent<Rigidbody2D>();
        player_collision = false;
        objecttransform = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = obj.GetComponent<Player_Action>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    // 0.02��
    private void FixedUpdate()
    {

        //�浹 �� 
        if(player_collision)
        {
            boxMoveTime += Time.deltaTime;
            switch(player.get_s_dir())
            {
                // ĳ���Ͱ� �����ʿ��� �ڽ��� �о��� ��
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

                        Debug.Log("�ڽ� �̵� �ð� " + boxMoveTime);
                        boxMoveTime = 0;

                        player_collision = false;
                        player.isCharacterSetter(false);
                    }
                    break;
                // ĳ���Ͱ� ���ʿ��� �ڽ��� �о��� �� 
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

                        Debug.Log("�ڽ� �̵� �ð� " + boxMoveTime);
                        boxMoveTime = 0;


                        player_collision = false;
                        player.isCharacterSetter(false);
                    }
                    break;
                // ĳ���Ͱ� ������ �ڽ��� �о��� ��
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

                        Debug.Log("�ڽ� �̵� �ð� " + boxMoveTime);
                        boxMoveTime = 0;

                        player_collision = false;
                        player.isCharacterSetter(false);
                    }
                    break;
                // ĳ���Ͱ� �Ʒ����� �ڽ��� �о��� ��
                case Constants.DU:
                    if (objecttransform.y + 0.9f >= transform.position.y)
                    {
                        player.isCharacterSetter(true);
                        box_rigidbody.constraints = RigidbodyConstraints2D.None;
                        box_rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

                        box_rigidbody.velocity = Vector2.up * 2;
                        

                        if (0.5 < boxMoveTime)
                        {
                            player_collision = false;
                            player.isCharacterSetter(false);
                            box_rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
                            box_rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;


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

                        Debug.Log("�ڽ� �̵� �ð� " + boxMoveTime);
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

    // �浹
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Player�� �浹�� !! ");

            if (collision.collider.tag == "Wall")
            {
                Debug.Log("Wall �浹�� !! ");

                player_collision = false;
                return;
            }


            player_collision = true;
        }

        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
            
    }

    // �޼ҵ�
    


}
