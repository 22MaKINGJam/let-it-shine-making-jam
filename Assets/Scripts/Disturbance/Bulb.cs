using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bulb : MonoBehaviour
{
    bool isColl = false;
    public Button btn;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isColl==false)
        {
            GameObject.Find("JumpBtn").GetComponent<Button>().interactable = false;
            isColl = true;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>().enabled=false;

            Invoke("MovePlayer", 0.5f);
        }
    }

    void MovePlayer()
    {
        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>().enabled = true;
        GameObject.Find("JumpBtn").GetComponent<Button>().interactable = true;
        isColl = false;
    }
}
