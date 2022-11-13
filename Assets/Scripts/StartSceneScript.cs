using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score;
    int maxScore;

    void Start()
    {
        maxScore=GameObject.Find("GameData").GetComponent<GameSaveData>().GetMaxScore();
        score.text = "최고점수 : "+maxScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)||Input.touchCount>0||Input.GetKeyDown(KeyCode.Tab))
        {
            GameObject.Find("SceneChange").GetComponent<SceneChange>().OnLoadStageOneScene();
        }
    }
}
