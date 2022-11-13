using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Panel_GameOver : MonoBehaviour
{
    public Text Text_GameResult;
    public Text Text_Best;
    private void Awake()
    {
        transform.gameObject.SetActive(false); 
    }

    public void Start()
    {
        Show();
    }

    public void Show()
    {
        int score = FindObjectOfType<Score>().Getfinal();
        FindObjectOfType<GameSaveData>().SaveScore(score);
        int best = FindObjectOfType<GameSaveData>().GetMaxScore();
        Text_GameResult.text = "Score : " + score.ToString();
        Text_Best.text="Best : "+ best.ToString();
    }

    public void OnClick_Retry() 
    {
        FindObjectOfType<Score>().Scorereset();
        FindObjectOfType<Canscore>().Canreset();//candy
        FindObjectOfType<Chescore>().Chereset();//cheese
        FindObjectOfType<Ginscore>().Ginreset();//cookie
        SceneManager.LoadScene("MainScene_yungin");
        Time.timeScale = 1f;//테스트신
        GameSaveData.isSuperJump = false;
        GameSaveData.life = 3;


    }

    public void OnClick_Main()
    {
        Application.Quit();//테스트신
    }
}
