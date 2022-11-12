using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDesktop : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;

    public float jumpPower;
    public float speed;


    public int jumpCnt = 0;
    private bool isPlatform = false;


    private void Awake()
    {
        anim = GetComponent<Animator>();
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

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isWalk", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("isWalk", false);
        }
    }

    private void Move()
    {
        float playerMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("isWalk", true);
            anim.SetBool("isLeft", true);
            playerMove = speed * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("isWalk", true);
            anim.SetBool("isLeft", false);
            playerMove = -speed * Time.deltaTime;
        }
        transform.Translate(new Vector3(playerMove, 0, 0));
    }


    void Jump()
    {
        GetComponent<AnimationController>().JumpTrigger();
        jumpCnt++;
        rigid.velocity = new Vector2(rigid.velocity.x, 0f);
        rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            GetComponent<Animator>().SetTrigger("Ground");
            isPlatform = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            GetComponent<Animator>().SetTrigger("Ground");
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
