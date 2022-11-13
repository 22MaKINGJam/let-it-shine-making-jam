using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void OnLoadStartScene()
    {
        PlayerPrefs.SetInt("isStart", 1);
        // 스타트 씬 로드
        SceneManager.LoadScene("1_StartScene");
    }

    public void OnLoadStageOneScene()
    {
        SceneManager.LoadScene("2_MainScene");

    }

    public void OnLoadStageTwoScene()
    {
        SceneManager.LoadScene("3_MainScene");

    }

    public void OnLoadEndScene()
    {
        SceneManager.LoadScene("4_EndScene");

    }
}
