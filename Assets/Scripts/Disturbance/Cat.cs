using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    Vector3 pos, currentPos;
    public float time = 10;
    SpriteRenderer spriterenderer;
    private float selectCountdown;
    public GameObject cat;
    bool isFadeIn = false;

    // Start is called before the first frame update
    void Start()
    {
        cat.SetActive(false);
        spriterenderer = cat.GetComponent<SpriteRenderer>();
        pos = GameObject.FindWithTag("Player").transform.position;
        selectCountdown = time;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = GameObject.FindWithTag("Player").transform.position;
        if (currentPos == pos)
        {
            if (Mathf.Floor(selectCountdown) <= 0)
            {
                if (isFadeIn == false)
                {
                    Debug.Log("hi");
                    fadeIn();
                    //GameOverManager.gameover();
                }
            }
            else
            {
                selectCountdown -= Time.deltaTime;
            }
        }
        else
        {
            pos = GameObject.FindWithTag("Player").transform.position;
            selectCountdown = time;
        }
    }

    void fadeIn()
    {
        cat.transform.position = currentPos;   
        cat.SetActive(true);
        StartCoroutine("FadeInStart");
        isFadeIn = true;
        Invoke("fadeOut", 2f);
    }

    void fadeOut()
    {
        StartCoroutine("FadeOutStart");
    }
    
    
    IEnumerator FadeInStart()
    {
       for(int i=0; i<10; i++)
        {
            float f = i / 10.0f;
            Color c = spriterenderer.material.color;
            c.a = f;
            spriterenderer.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }

    //페이드 인
    IEnumerator FadeOutStart()
    {
        SpriteRenderer player = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        for (int i = 10; i >= 0; i--)
        {
            float f = i / 10.0f;
            Color c = spriterenderer.material.color;
            c.a = f;
            spriterenderer.material.color = c;
            player.color = c;
            yield return new WaitForSeconds(0.1f);

        }
        GameObject.Find("GameManager").GetComponent<GameOverManager>().gameOver("앗! 고양이한테 잡혀버렸어…멈추면 안돼! ");

    }

}


