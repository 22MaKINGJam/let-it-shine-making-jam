using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chescore : MonoBehaviour
{
    public Text text;
    public static int che_score = 0;

    private void Start()
    {
        SetText();
    }

    public void GetScore()
    {
        che_score += 1;
        SetText();
    }

    public void SetText()
    {
        text.text = " : " + che_score.ToString();
    }

}