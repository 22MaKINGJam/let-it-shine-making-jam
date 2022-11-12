using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public VariableJoystick joy;    //조이스틱
    public Button jumpBtn;  //점프 버튼

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    public float jumpPower;
    public float speed;

    public int jumpCnt = 0;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumpBtn.onClick.AddListener(changeJump);    
    }

    // Update is called once per frame
    void Update()
    {
        float x = joy.Horizontal;
 
        Move(x);

        if (x < 0)  //player 방향
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
    
    void changeJump()
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

    private void Move(float x)
    {
        float playerMove = x * speed * Time.deltaTime;
        transform.Translate(new Vector3(playerMove, 0, 0));
    }


    void Jump()
    {
        jumpCnt++;
        rigid.velocity = new Vector2(rigid.velocity.x, 0f);
        rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
    }
}
