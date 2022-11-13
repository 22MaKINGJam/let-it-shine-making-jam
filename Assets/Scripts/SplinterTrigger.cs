using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplinterTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckIfPlayer(collision);
    }
    private void CheckIfPlayer(Collider2D collision) // 2. 플레이어가 가시에 닿으면 죽음.
    {
        if (collision.gameObject == GameObject.FindWithTag("Player") && !GameObject.Find("DisturbanceManager").GetComponent<DisturbanceManager>().isSheild)
        {
            Debug.Log("플레이어가 가시에 닿음");
            GameOverManager.gameover();
        }
    }
}