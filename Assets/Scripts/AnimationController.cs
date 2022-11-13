using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ToggleAnim(string animation, bool value)
    {
       anim.SetBool(animation, value);
    }


    public void JumpTrigger()
    {
        if (anim.GetBool("isLeft"))
        {
            anim.SetTrigger("JumpLeft");
        }
        else
        {
            anim.SetTrigger("JumpRight");
        }
    }

    public void SuperJumpTrigger()
    {
        if (anim.GetBool("isLeft"))
        {
            anim.SetTrigger("SuperJumpLeft");
        }
        else
        {
            anim.SetTrigger("SuperJumpRight");
        }
    }

    public void DownTrigger()
    {
        if (anim.GetBool("isLeft"))
        {
            anim.SetTrigger("DownLeft");
        }
        else
        {
            anim.SetTrigger("DownRight");
        }
    }

    public void GroundTrigger()
    {
        anim.SetTrigger("Ground");
    }

    public void ElectricTrigger()
    {
        anim.SetTrigger("Electric");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
