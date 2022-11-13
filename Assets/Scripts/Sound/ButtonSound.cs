using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;
    public static ButtonSound _buttonInstance;

    public AudioClip cookie;
    public AudioClip cheeze;
    public AudioClip jump1;
    public AudioClip jump2;
    public AudioClip gift;
    public AudioClip gameOver;
    public AudioClip nextStep;

    // Start is called before the first frame update
    void Awake()
    {
        _buttonInstance = this;
    }

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>(); //GameManager 오브젝트
    }

    public void OnCookie()
    {
        audioSource.clip = cookie;
        audioSource.Play();
    }
    public void OnCheeze()
    {
        audioSource.clip = cheeze;
        audioSource.Play();
    }
    public void OnJump1()
    {
        audioSource.clip = jump1;
        audioSource.Play();
    }
    public void OnJump2()
    {
        audioSource.clip = jump2;
        audioSource.Play();
    }
    public void OnGift()
    {
        audioSource.clip = gift;
        audioSource.Play();
    }
    public void OnGameOver()
    {
        audioSource.clip = gameOver;
        audioSource.Play();
    }
    public void OnNextStep()
    {
        audioSource.clip = nextStep;
        audioSource.Play();
    }
}