using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    
    public void Btn_retry()
    {
        SceneManager.LoadScene("MainScene_yungin2");
        Time.timeScale = 1f;
    }

}
