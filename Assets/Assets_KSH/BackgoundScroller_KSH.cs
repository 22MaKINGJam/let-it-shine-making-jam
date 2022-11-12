using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgoundScroller_KSH : MonoBehaviour
{
    public float speed;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;
    float viewHeight;

    private void Awake()
    {
        viewHeight = Camera.main.orthographicSize * 2; // 카메라 사이즈*2 = 카메라 뷰의 높이.
    }
    void Update()
    {
        Vector3 curpos = transform.position;
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        transform.position = curpos + nextPos;

        if (sprites[endIndex].position.y < viewHeight*(-1)) // 높이가 카메라보다 작아지면 넘기기.
        { 
            Vector3 backSpritePos = sprites[startIndex].localPosition;
            Vector3 frontSpritePos = sprites[endIndex].localPosition;
            sprites[endIndex].transform.localPosition = backSpritePos + Vector3.up * 10;

            // 인덱스 갱신.
            int startIndexSave = startIndex;
            startIndex = endIndex;
            endIndex = (startIndexSave - 1 == -1) ? sprites.Length - 1 : startIndexSave - 1;
        }

    }
}
