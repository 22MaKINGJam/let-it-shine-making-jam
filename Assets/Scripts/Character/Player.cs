using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public VariableJoystick joy;    //조이스틱
    public Button jumpBtn;  //점프 버튼

    Rigidbody2D rigid;
    Animator anim;
    public float jumpPower;
    public float speed;

    public int jumpCnt = 0;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        jumpBtn.onClick.AddListener(changeJump);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = joy.Horizontal;
        Move(x);

        if (rigid.velocity.y < 0)
        {
            GetComponent<AnimationController>().DownTrigger();
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
        if (x < 0)
        {
            anim.SetBool("isLeft", true);
        }
        else if(x > 0)
        {
            anim.SetBool("isLeft", false);
        }
    }


    void Jump()
    {
        GetComponent<AnimationController>().JumpTrigger();
        jumpCnt++;
        rigid.velocity = new Vector2(rigid.velocity.x, 0f);
        rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
    }
}
