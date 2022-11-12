using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCreator : MonoBehaviour
{
    public GameObject middle1;
    public GameObject middle2;
    public GameObject first;
    public GameObject end;
    public int backgroundNumbers = 20;

    private int backgroundLength;
    private int y = 0;
    // Start is called before the first frame update
    void Start()
    {
        CreateBackground();
    }

   private void CreateBackground()
    {
        backgroundLength = backgroundNumbers * 10 + 20; // 중간개수*10 + 처음 + 마지막.

        y = 0;
        y = SetPosition(first, y);
        for (int i = 0; i < backgroundNumbers; i++)
        {
            if (i % 2 == 0)
            {
                //SetPosition(middle1, y);
                y = SetPosition(middle1, y);
            }
            else
            {
                // middle2생성
                SetPosition(middle2, y);
                y = SetPosition(middle2, y);
            }
        }
            SetPosition(end, y);

    }

    public int SetPosition(GameObject background, int y)
    {
        Vector3 creatingPoint = new Vector3(0, y,0);
        y += 10;
        Instantiate(background, creatingPoint, Quaternion.identity);
        return y;
    }
}
