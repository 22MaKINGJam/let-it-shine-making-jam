using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFromPlatformBelow : MonoBehaviour
{
    private float playerPos;
    private float platPos;
    void OnTriggerEnter2D(Collider2D collider)
    {
        playerPos = GameObject.FindWithTag("Player").transform.position.y;
        platPos = this.transform.position.y;
        if (collider.transform.tag == "Player" && playerPos - platPos < 0) // 플레이어가 아래에 있음.
        {
            Physics2D.IgnoreCollision(collider, gameObject.GetComponent<Collider2D>(),true);
           //  public static void IgnoreCollision(Collider collider1, Collider collider2, bool ignore = true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Physics2D.IgnoreCollision(collision, gameObject.GetComponent<Collider2D>(),false);
        }
    }

}

