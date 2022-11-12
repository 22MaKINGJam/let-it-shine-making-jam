using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class DividePlatform : MonoBehaviour
{
    Animator animator;
    GameObject player;
    float playerPos;
    public GameObject platformPrefab;

    private void Awake()
    {
       // StartCoroutine("PlayerPosition");
        player = GameObject.FindWithTag("Player");
        animator = this.GetComponent<Animator>();
    }
    private void Start()
    {
        int x = Random.Range(0, 100);
        if (x < 100 && x > 82)
        {
                animator.SetTrigger("splintTrigger");// "파라미터이름", 바꿀 값.

        }
    }
    /*
    private void Update()
    {
        playerPos = player.transform.position.y;
        //RunSplinterAnim();
    }
    IEnumerator SplinterPop()
    {
        yield return new WaitForSeconds(0.5f);
        RunSplinterAnim();

    }
   /* IEnumerator PlayerPosition()
    {
        yield return new WaitForSeconds(0.3f);
        playerPos = player.transform.position.y;
    }

    void RunSplinterAnim()
    {
        int x = Random.Range(0, 100);
        if (x < 100 && x > 50)
        {
            if (playerPos-2 < platformPrefab.transform.position.y && platformPrefab.transform.position.y < playerPos + 2)
            {
                animator.SetTrigger("splintTrigger");// "파라미터이름", 바꿀 값.
            }

        }
    }
    */
}