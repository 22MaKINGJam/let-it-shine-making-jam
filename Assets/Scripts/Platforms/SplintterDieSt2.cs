using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplintterDieSt2 : MonoBehaviour
{
    private float playerPos;
    private float platPos;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerPos = GameObject.FindWithTag("Player").transform.position.y;
        platPos = this.transform.position.y;
        if (collision.transform.tag == "Player" ) // 플레이어가 위에 있음.
        {
            Debug.Log("플레이어가 가시에 닿음");
            GameOverManager.gameover();

        }
    }

}
