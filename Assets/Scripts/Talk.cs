using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    public int talkCnt;       // 대화의 총 갯수
    public string[] name;          // 이름 저장
    public string[] talk;          // 대화 저장
    public int[] showCnt;
    public Text txtName;
    public Text txtSentence;
    GameObject mouse1, mouse2;
    int strCnt = 0;
    bool is_full=false, cut=false;

    IEnumerator Typing(Text txtSentence, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            if (cut == true)
            {
                break;
            }
            txtSentence.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }
        txtSentence.text = message;
        yield return new WaitForSeconds(0.1f);
        is_full = true;
    }

    void Start()
    {
        mouse1 = GameObject.Find("Canvas").transform.Find("Mouse1").gameObject;
        mouse2 = GameObject.Find("Canvas").transform.Find("Mouse2").gameObject;
        //talk = new string[talkCnt]; // 대화 저장 공간을 초기화해줍니다.
        //showCnt = new int[talkCnt];
        mouse1.SetActive(false);
        mouse2.SetActive(false);
        StartCoroutine(Typing(txtSentence, talk[0], 0.1f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            mouse1.SetActive(false);
            mouse2.SetActive(false);
            if (strCnt < talkCnt-1)
            {
                if (is_full == true)    //모든 텍스트 출력된 상태일 때
                {
                    strCnt++;
                    is_full = false;
                    cut = false;
                    showAll();
                    StartCoroutine(Typing(txtSentence, talk[strCnt], 0.1f));    
                }
                else
                {
                    cut = true;
                }
            }
            else
            {
                GameObject.Find("SceneChange").GetComponent<SceneChange>().OnLoadStageOneScene();
            }
        }
       
    }
    void showAll()
    {

        txtName.text = name[strCnt];
        //txtSentence.text = talk[strCnt];
        //Debug.Log(txtName.text);
        if (txtName.text == "생쥐1")
        {
            mouse1.SetActive(true);
        }
        else if (txtName.text == "생쥐2")
        {
            mouse2.SetActive(true);
        }

    }

    void fadeOut()
    {

    }
}