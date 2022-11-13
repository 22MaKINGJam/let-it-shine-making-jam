using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameOverManager : MonoBehaviour
{
    public Camera mainCamera;
    public static Action gameover;
    private float cameraBottom;

    private float height;

    private void Awake()
    {
        gameover = () => { gameOver(); };
        height = this.GetComponent<BoxCollider2D>().bounds.size.y;
    }

    void Update()
    {
        CheckIfFall();
    }

    private void CheckIfFall() // 1. 카메라 밖으로 떨어지면 죽음.
    {
        cameraBottom = mainCamera.transform.position.y - 5;
        if (this.transform.position.y - height/2 < cameraBottom)
        {
            gameOver();
        }
    }


    public void gameOver()
    {
        Debug.Log("게임오버");
        GameObject.Find("Canvas").transform.Find("Panel_GameOver").gameObject.SetActive(true);
        Time.timeScale = 0f;

        //GameObject.Find("finalobject").GetComponent<Panel_GameOver>().Show();
       // GameObject.Find("Canvas").transform.FindChild("UI_gg").gameObject.SetActive(true);
       // GameObject.Find("UI_gg").GetComponent<UI_Gameover>().Show();


        //FindObjectOfType<JUMP>().Die();        // FindObjectOfType<PlatformManager>().Stop(); // 발판 그만 만들어.
        //GameObject.Find("Canvas").transform.FindChild("UI_gg").gameObject.SetActive(true);
        //GameObject.Find("UI_gg").GetComponent<UI_Gameover>().Show();//게임오버
        // 게임오버되면? 메인으로 씬 전환? 기획애니메이션으로 씬 전환?*/
    }
}