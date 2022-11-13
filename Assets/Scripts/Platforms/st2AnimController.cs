using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class st2AnimController : MonoBehaviour
{
    void Start()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("isTrigger");
    }


}
