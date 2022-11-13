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
        lifeObj.GetComponent<Image>().sprite = lifes[GameSaveData.life];
    }
}
