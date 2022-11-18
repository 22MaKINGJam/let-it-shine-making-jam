using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFromPlatformBelow : MonoBehaviour
{
    public Camera mainCamera;

    private float playerPos;
    private float platPos;
    private float cameraBottom;
    
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
            Physics2D.IgnoreCollision(collision, gameObject.GetComponent<Collider2D>(), false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        cameraBottom = GameObject.FindWithTag("MainCamera").transform.position.y - 5;
        platPos = this.transform.position.y;
        if (platPos < cameraBottom) // 플랫폼이 카메라보다 아래에 있음
        {
            Destroy(this.gameObject);
        }
    }

}

