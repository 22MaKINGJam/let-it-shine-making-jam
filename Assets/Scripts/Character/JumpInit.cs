using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpInit : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.relativeVelocity.y);
        if (collision.relativeVelocity.y <= 0.5f) // 플레이어가 아래에서 옴.
        {
            GameObject.FindWithTag("Player").GetComponent<Animator>().SetTrigger("Ground");
            collision.gameObject.GetComponent<PlayerDesktop>().jumpCnt = 0;
            collision.gameObject.GetComponent<Player>().jumpCnt = 0;
        }
    }

}
