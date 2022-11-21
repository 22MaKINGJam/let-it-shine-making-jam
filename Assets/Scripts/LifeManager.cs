using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public Sprite[] lifes;
    public GameObject lifeObj;
    private void Start()
    {
        lifeObj.GetComponent<Image>().sprite = lifes[GameSaveData.life];
    }

    public void LifeDown()
    {
        GameSaveData.life--;
        if(GameSaveData.life >= 0)
        {
            lifeObj.GetComponent<Image>().sprite = lifes[GameSaveData.life];
        }
    }

    public void LifeUp()
    {
        if (GameSaveData.life == 1 || GameSaveData.life == 2) // 0 또는 3이면 추가 X
        {
            GameSaveData.life++;
            Debug.Log("하트 하나 추가!");
            lifeObj.GetComponent<Image>().sprite = lifes[GameSaveData.life];
        }
    }
}
