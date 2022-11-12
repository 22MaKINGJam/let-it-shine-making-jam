using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpInit : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f && collision.transform.tag == "Player") // 플레이어가 아래에서 옴.
        {
            Debug.Log(collision.gameObject.GetComponent<PlayerDesktop>());
            collision.gameObject.GetComponent<PlayerDesktop>().jumpCnt = 0;
            collision.gameObject.GetComponent<Player>().jumpCnt = 0;
        }
    }

}
