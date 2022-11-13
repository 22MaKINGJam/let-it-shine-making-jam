using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplinterTrigger : MonoBehaviour
{
    private float playerPos;
    private float platPos;
    void OnTriggerEnter2D(Collider2D collider)
    {
        playerPos = GameObject.FindWithTag("Player").transform.position.y;
        platPos = this.transform.position.y;
        if (collider.transform.tag == "Player" && playerPos - platPos > 0 && !GameObject.Find("DisturbanceManager").GetComponent<DisturbanceManager>().isSheild) // 플레이어가 위에 있음.
        {
            Debug.Log("플레이어가 가시에 닿음");
            GameOverManager.gameover();

        }

    }

}