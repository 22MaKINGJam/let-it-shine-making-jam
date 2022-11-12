using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canscore : MonoBehaviour
{
    public Text text;
    public static int can_score = 0;

    private void Start()
    {
        SetText();
    }

    public void GetScore()
    {
        can_score += 1;
        SetText();
    }

    public void SetText()
    {
        text.text = " : " + can_score.ToString();
    }

}