﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJumpInit : MonoBehaviour
{
    public GameObject superJumpPopup;
    public GameObject superJumpYesPopup;
    public GameObject superJumpNoPopup;
    public float superJumpPower;

    // Start is called before the first frame update
    void Start()
    {
        if (GameSaveData.isSuperJump)
        {
            superJumpPopup.SetActive(true);
        }
    }

    public void OnYesButton()
    {
        superJumpYesPopup.SetActive(true);
        Invoke("SuperJumpInvoke", 1f);
    }

    void SuperJumpInvoke()
    {
        superJumpYesPopup.SetActive(false);
        Invoke("SuperJumpStart", 1f);
    }

    void SuperJumpStart()
    {
        // 슈퍼점프!
        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().AddForce(Vector3.up * superJumpPower, ForceMode2D.Impulse);
        GameObject.FindWithTag("Player").GetComponent<AnimationController>().SuperJumpTrigger();
    }

    public void OnNoButton()
    {
        superJumpNoPopup.SetActive(true);
        Invoke("OnActiveFalse", 1f);        
    }

    void OnActiveFalse()
    {
        superJumpNoPopup.SetActive(false);
    }
}