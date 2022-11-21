using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            //캐릭터 움직임 비활성
            GameObject.Find("Joystick").GetComponent<VariableJoystick>().enabled = false;
            GameObject.Find("JumpBtn").GetComponent<Button>().interactable = false;
            GameObject.FindWithTag("Player").GetComponent<Player>().enabled = false;
            GameObject.FindWithTag("Player").GetComponent<PlayerDesktop>().enabled = false;

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
        TurnPlayerActive();
        GameObject.Find("DisturbanceManager").GetComponent<DisturbanceManager>().StartShield();
        ButtonSound._buttonInstance.OnJump2();
        // 슈퍼점프!
        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().AddForce(Vector3.up * superJumpPower, ForceMode2D.Impulse);
        GameObject.FindWithTag("Player").GetComponent<AnimationController>().SuperJumpTrigger();
        GameObject.Find("DisturbanceManager").GetComponent<DisturbanceManager>().EndShield();
    }

    public void OnNoButton()
    {
        superJumpNoPopup.SetActive(true);
        Invoke("OnActiveFalse", 1f);        
    }

    void OnActiveFalse()
    {
        TurnPlayerActive();
        superJumpNoPopup.SetActive(false);
    }


    void TurnPlayerActive()
    {
        //캐릭터 움직임 활성
        GameObject.Find("Joystick").GetComponent<VariableJoystick>().enabled = true;
        GameObject.Find("JumpBtn").GetComponent<Button>().interactable = true;
        GameObject.FindWithTag("Player").GetComponent<Player>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<PlayerDesktop>().enabled = true;
    }
}
