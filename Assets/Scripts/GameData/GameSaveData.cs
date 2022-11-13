using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSaveData : MonoBehaviour
{
    // PlayerPrefs에 저장
    public bool isStart = false;
    public int maxScore = 0;

    // 그냥 게임실행마다 관리
    public static bool isSuperJump = true;
    public static int life = 3;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        var obj = FindObjectsOfType<GameSaveData>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("maxScore"))
        {
            maxScore = PlayerPrefs.GetInt("maxScore");
        }
        else
        {
            PlayerPrefs.SetInt("maxScore", 0);
        }
    }

    public int GetMaxScore()
    {
        if (PlayerPrefs.HasKey("maxScore"))
        {
            return PlayerPrefs.GetInt("maxScore");
        }
        return 0;
    }

    public void SaveScore(int score)
    {
        if(score > maxScore)
        {
            PlayerPrefs.SetInt("maxScore", score);
        }
    }
}
