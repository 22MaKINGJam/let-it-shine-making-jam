using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Platforms : MonoBehaviour
{

    public Sprite[] sprites;
    private int number;
    private float x, y;

    public void SetSprite(int idx)
    {
        number = idx;
        x = transform.position.x;
        y = transform.position.y;
        GetComponent<SpriteRenderer>().sprite = sprites[idx];
    }


}
