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
        PlayerPrefs.SetInt("isStart", 1);
        SceneManager.LoadScene("2_MainScene");

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
