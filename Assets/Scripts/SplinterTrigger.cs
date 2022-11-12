using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplinterTrigger : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckIfPlayer(collision);
    }
    private void CheckIfPlayer(Collider2D collision) // 2. 플레이어가 가시에 닿으면 죽음.
    {
        if (collision.gameObject.Equals(player))
        {
            GameOverManager.gameover();
        }
    }
}
