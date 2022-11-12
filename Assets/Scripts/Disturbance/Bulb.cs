using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : MonoBehaviour
{
    Rigidbody2D rigid;
    bool isColl = false;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isColl==false)
        {
            isColl = true;
            rigid.bodyType = RigidbodyType2D.Static;
            GameObject.Find("Player").GetComponent<BoxCollider2D>().enabled=false;

            Invoke("MovePlayer", 0.5f);
        }
    }

    void MovePlayer()
    {
        rigid.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject.Find("Player").GetComponent<BoxCollider2D>().enabled = true;
        isColl = false;
    }
}
