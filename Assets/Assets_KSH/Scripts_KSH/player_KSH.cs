using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class player_KSH : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed = 10f; // 움직이는 속도를 빠르게.
    float movement = 0f;
    public static Action screenlimit;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;

    }
    private void FixedUpdate() //physics
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
        LimitByScreen();
    }
    public void LimitByScreen() // (추가) 캐릭터가 화면 안에서만 이동하게 하는 함수.
    {
        Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worldpos.x < 0.05f) worldpos.x = 0.05f;
        if (worldpos.x > 0.95f) worldpos.x = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worldpos);

    }
}
