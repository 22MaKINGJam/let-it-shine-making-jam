using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class SetSplinterAnim : MonoBehaviour
{
    Animator animator;
    GameObject player;
    float playerPos;
    public GameObject platformPrefab;
    public float percentage;

    private void Awake()
    {
        // StartCoroutine("PlayerPosition");
        player = GameObject.FindWithTag("Player");
        animator = this.GetComponent<Animator>();
    }
    private void Start()
    {
        int x = Random.Range(0, 1000);
        if (x < 1000 && x > percentage)
        {
            animator.SetTrigger("splintTrigger");// "파라미터이름", 바꿀 값.

        }
        else Destroy(this.gameObject);
    }
    
}