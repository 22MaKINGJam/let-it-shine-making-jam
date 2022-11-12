using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDesktop : MonoBehaviour
{
    Rigidbody2D rigid;
    public float jumpPower;
    public float speed;


    public int jumpCnt = 0;


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
            if (jumpCnt == 0)
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
        rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
    }
}
