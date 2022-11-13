using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Clear : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("스테이지 원 클리어!");
            GameObject.Find("SceneChange").GetComponent<SceneChange>().OnLoadEndScene();
        }
        else if (collision.gameObject.tag.Equals("Platform"))
        {
            Destroy(collision.gameObject);
        }
    }
}
