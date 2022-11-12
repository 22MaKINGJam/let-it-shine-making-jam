using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameOverManager : MonoBehaviour
{
    public Camera mainCamera;
    public static Action gameover;
    private float cameraBottom;

    public GameObject splinter;
    private float height;
    private void Awake()
    {
        gameover = () => { GameOver(); };
        splinter = GameObject.FindWithTag("Splinter");
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
            GameOver();
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    CheckIfSplinter(collision);
    //}

    //private void CheckIfSplinter(Collider2D collision) // 2. 플레이어가 가시에 닿으면 죽음.
    //{
    //    if (collision.gameObject.Equals(splinter))
    //    {
    //        GameOver();
    //    }
    //}

    public void GameOver()
    {
        Debug.Log("게임오버");
        // 게임오버되면? 메인으로 씬 전환? 기획애니메이션으로 씬 전환?
    }
}