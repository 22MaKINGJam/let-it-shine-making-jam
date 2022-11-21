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

        // 쉴드 중이면 
        if (GameObject.Find("DisturbanceManager").GetComponent<DisturbanceManager>().isSheild)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isColl==false)
        {
            isColl = true;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GameObject.FindWithTag("Player").GetComponent<AnimationController>().ElectricTrigger();

            //캐릭터 움직임 비활성
            GameObject.Find("Joystick").GetComponent<VariableJoystick>().enabled = false;
            GameObject.Find("JumpBtn").GetComponent<Button>().interactable = false;
            GameObject.FindWithTag("Player").GetComponent<Player>().enabled = false;
            GameObject.FindWithTag("Player").GetComponent<PlayerDesktop>().enabled = false;

            GameObject.Find("LifeManager").GetComponent<LifeManager>().LifeDown();
            if (GameSaveData.life == 0)
            {
                GameObject.Find("GameManager").GetComponent<GameOverManager>().gameOver("결국 생쥐들의 크리스마스는 반짝반짝거리지 못했다…");
            }
            Invoke("MovePlayer", 1f);
        }
    }

    void MovePlayer()
    {
        //캐릭터 움직임 활성
        GameObject.FindWithTag("Player").GetComponent<Player>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<PlayerDesktop>().enabled = true;
        GameObject.Find("Joystick").GetComponent<VariableJoystick>().enabled = true;

        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GameObject.FindWithTag("Disturbance").GetComponent<Bulb>().enabled = false;
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
