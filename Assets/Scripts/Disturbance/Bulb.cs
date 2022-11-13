using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bulb : MonoBehaviour
{
    bool isColl = false;
    SpriteRenderer spriteRenderer;
    public GameObject bulb;


    public Sprite[] sprites;

    void Start()
    {
        random_image();
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isColl==false)
        {
            GameObject.Find("JumpBtn").GetComponent<Button>().interactable = false;
            isColl = true;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GameObject.FindWithTag("Player").GetComponent<AnimationController>().ElectricTrigger();
            
            //캐릭터 움직임 비활성
            GameObject.Find("Joystick").GetComponent<VariableJoystick>().enabled = false;
            GameObject.Find("JumpBtn").GetComponent<Button>().enabled = false;
            GameObject.Find("Player").GetComponent<PlayerDesktop>().enabled = false;

            Invoke("MovePlayer", 1.5f);
        }
    }

    void MovePlayer()
    {
        //캐릭터 움직임 활성
        GameObject.Find("Joystick").GetComponent<VariableJoystick>().enabled = true;
        GameObject.Find("JumpBtn").GetComponent<Button>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerDesktop>().enabled = true;

        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GameObject.Find("Bulb").GetComponent<BoxCollider2D>().enabled = false ;
        //GameObject.FindWithTag("Player").GetComponent<Animator>().SetBool("isElectric", false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>().enabled = true;
        GameObject.Find("JumpBtn").GetComponent<Button>().interactable = true;

    }

    void random_image()
    {
        int index = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[index];

    }
}
