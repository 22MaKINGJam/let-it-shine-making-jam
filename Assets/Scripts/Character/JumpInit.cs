using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpInit : MonoBehaviour
{
    GameObject player;
    Animator playerAnim;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerAnim = player.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.relativeVelocity.y);
        if (collision.relativeVelocity.y <= 0.5f) // 플레이어가 아래에서 옴.
        {
            playerAnim.SetTrigger("Ground");
            collision.gameObject.GetComponent<PlayerDesktop>().jumpCnt = 0;
            collision.gameObject.GetComponent<Player>().jumpCnt = 0;
        }
    }

}
