﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Locate_min : MonoBehaviour
{
    public Slider sliderA;
   // public Transform target;
    float first;
    float second;
    float third;
    float maxY = 0;


    // Start is called before the first frame update
    void Start()
    {
        first = GameObject.FindWithTag("Player").transform.position.y;//1만큼 개수 증가);

    }

    // Update is called once per frame
    void Update()
    {
        second = GameObject.FindWithTag("Player").transform.position.y;
        if (second/200 > maxY)
        {
           maxY = second/200;
           GameObject.Find("mainobject").GetComponent<Score>().PlatScore();
        }
        sliderA.value = second/200;
    }
}
