using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameOverManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject gameOverPopup;
    public GameObject player;

    private float cameraBottom;

    private float height, width;

    private bool isOver = false;

    private void Awake()
    {
        height = player.GetComponent<BoxCollider2D>().bounds.size.y;
        width = player.GetComponent<BoxCollider2D>().bounds.size.x;
    }

    void Update()
    {
        CheckIfFall();
        CheckIfOut();
    }

    private void CheckIfOut()
    {
        float cameraWidth = mainCamera.transform.position.x;
        if (player.transform.position.x + width / 2 < cameraWidth - 3f)
        {
            player.transform.position = new Vector2(cameraWidth + 3f,player.transform.position.y);
        }
        else if (player.transform.position.x - width / 2 > cameraWidth + 3f)
        {
            player.transform.position = new Vector2(cameraWidth - 3f, player.transform.position.y);
        }
    }

    private void CheckIfFall() // 1. 카메라 밖으로 떨어지면 죽음.
    {
        cameraBottom = mainCamera.transform.position.y - 5;
        if (player.transform.position.y + height/2 < cameraBottom && !isOver)
        {
            isOver = true;
            gameOver("결국 생쥐들의 크리스마스는 반짝반짝거리지 못했다…");
        }
    }


    public void gameOver(string msg)
    {
        Debug.Log("게임오버");
        gameOverPopup.GetComponent<Panel_GameOver>().gameOverMsg = msg;
        gameOverPopup.SetActive(true);
    }
}