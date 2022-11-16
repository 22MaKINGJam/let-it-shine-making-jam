using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Panel_GameOver : MonoBehaviour
{
    public Text Text_GameResult;
    public Text Text_Best;
    public Text gameOverText;
    public string gameOverMsg = "";

    public RuntimeAnimatorController originPlayer;

    public void Start()
    {
        Show();
        Time.timeScale = 0f;
    }

    public void Show()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().enabled = false;
        GameObject.FindWithTag("Player").GetComponent<PlayerDesktop>().enabled = false;
        GameObject.Find("JumpBtn").GetComponent<Button>().interactable = false;
        GameObject.Find("Joystick").GetComponent<VariableJoystick>().enabled = false;

        int score = FindObjectOfType<Score>().Getfinal();
        FindObjectOfType<GameSaveData>().SaveScore(score);
        int best = FindObjectOfType<GameSaveData>().GetMaxScore();
        Text_GameResult.text = "Score : " + score.ToString();
        Text_Best.text="Best : "+ best.ToString();

        if(gameOverText != null)
        {
            gameOverText.text = gameOverMsg;
        }
    }

    public void OnClick_Retry() 
    {
        FindObjectOfType<Score>().Scorereset();
        FindObjectOfType<Canscore>().Canreset();//candy
        FindObjectOfType<Chescore>().Chereset();//cheese
        FindObjectOfType<Ginscore>().Ginreset();//cookie

        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        player.GetComponent<Animator>().runtimeAnimatorController = originPlayer;


        Time.timeScale = 1f;//테스트신
        GameSaveData.isSuperJump = false;
        GameSaveData.life = 3;
       
        SceneManager.LoadScene("2_MainScene");
    }

    public void OnClick_Main()
    {
        Application.Quit();//테스트신
    }
}
