using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    public static int score = 0;


    private void Start()
    {
        SetText();
    }

    public void GetScore()
    {
        score += 50;
        SetText();
    }

    public void PlatScore()
    {
        score += 1;
        SetText();
    }



    public void SetText()
    {
        text.text = "Score : " + score.ToString();
    }

    public void ScoreUpdate()
    {
        text.text = score.ToString();
    }
}