using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public AudioClip stage2;
    public void OnLoadStartScene()
    {
        // 스타트 씬 로드
        SceneManager.LoadScene("1_StartScene");
    }

    public void OnLoadStageOneScene()
    {
        if (PlayerPrefs.HasKey("isStart"))
        {
            GameObject.Find("GameData").GetComponent<GameSaveData>().LoadData();
            SceneManager.LoadScene("2_MainScene");
        }
        else
        {
            PlayerPrefs.SetInt("isStart", 1);
            // 스토리 씬 로드
            SceneManager.LoadScene("0_StoryScene");
        }
    }

    public void OnLoadStageTwoScene()
    {
        BackgroundSound.bgm.clip = stage2;
        BackgroundSound.bgm.Play();

        SceneManager.LoadScene("3_MainScene");

    }

    public void OnLoadEndScene()
    {
        SceneManager.LoadScene("4_EndScene");

    }
}
