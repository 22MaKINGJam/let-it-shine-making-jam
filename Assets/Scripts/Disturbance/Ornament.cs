using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ornament : MonoBehaviour
{
    Vector3 pos;
    float delta = 2.0f;
    float speed = 1.5f;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    public Sprite[] sprites;


    void Start()
    {
        random_image();
        pos = transform.position;
    }
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }

    void random_image()
    {
        int index = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[index];
     
    }
}
