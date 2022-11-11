using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    public float jumpPower;
    public float speed;
    bool isJump = false;
    bool isDoubleJump = false;


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
            if (!isJump)
            {
                Jump();
            }
            else if (isDoubleJump)
            {
                Jump();
                isDoubleJump = false;
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
        isJump = true;
        isDoubleJump = true;
        rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flatform")
        {
            isJump = false;
        }
    }
}
