using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDesktop : MonoBehaviour
{
    Rigidbody2D rigid;
    public float jumpPower;
    public float speed;


    public int jumpCnt = 0;
    private bool isPlatform = false;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCnt == 0 && isPlatform)
            {
                Jump();
            } 
            else if (jumpCnt == 1)
            {
                Jump();
            }
        }
    }

    private void Move()
    {
        float playerMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerMove = speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerMove = -speed * Time.deltaTime;
        }
        transform.Translate(new Vector3(playerMove, 0, 0));
    }


    void Jump()
    {
        jumpCnt++;
        rigid.velocity = new Vector2(rigid.velocity.x, 0f);
        rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isPlatform = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isPlatform = false;
        }
    }
}
