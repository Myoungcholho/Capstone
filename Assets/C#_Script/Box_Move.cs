using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Move : MonoBehaviour
{
    Rigidbody2D box_rigidbody;
    float speed;
    bool player_collision;
    Vector3 objecttransform;

    private void Awake()
    {
        box_rigidbody = GetComponent<Rigidbody2D>();        
    }

    // Start is called before the first frame update
    void Start()
    {
        player_collision = false;
        objecttransform = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    // 0.02초
    private void FixedUpdate()
    {

       

        if(player_collision)
        {

            if ( objecttransform.x - 1.0f <= transform.position.x  && objecttransform.x + 1.0f >= transform.position.x  )
            {
                box_rigidbody.velocity = Vector2.right * 2;
            }
            else
            {
                box_rigidbody.velocity = Vector2.zero;

                Vector3 temp = objecttransform;
                temp.x += 1.0f;
                transform.position = temp;
                objecttransform = transform.position;


                player_collision = false;
            }
        }

    }

    // 충돌
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Debug.Log("Player와 충돌함 !! ");
            
            player_collision = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
            
    }

}
