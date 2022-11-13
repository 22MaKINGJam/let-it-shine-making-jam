using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSound : MonoBehaviour
{
    public static GameObject gameManager;
    public static AudioSource bgm;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        bgm = gameManager.GetComponent<AudioSource>(); //배경음악 저장해둠
        if (bgm.isPlaying) return; //배경음악이 재생되고 있다면 패스
        else
        {
            bgm.Play();
            DontDestroyOnLoad(gameManager); 
        }
    }
}
