using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ginscore : MonoBehaviour
{
    public Text text;
    public static int gin_score = 0;

    private void Start()
    {
        SetText();
    }

    public void GetScore()
    {
        gin_score += 1;
        SetText();
    }

    public void SetText()
    {
        text.text = " : " + gin_score.ToString();
    }

}