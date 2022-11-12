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
        anim.SetTrigger("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
