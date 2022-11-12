using System.Collections;
using System.Collections.Generic;
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

    public void SetText()
    {
        text.text = "Score : " + score.ToString();
    }

}