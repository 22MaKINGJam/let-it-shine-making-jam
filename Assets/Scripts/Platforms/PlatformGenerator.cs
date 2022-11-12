using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public Camera mainCamera;
    public GameObject player;
    public int numberOfPlatforms;
    public float levelWidth = 3f;
    public float minY = .7f;
    public float maxY = 1.5f;
    float playerPos;

    private float camerapos;
    Vector3 spawnPosition;
    Animator animator;
    GameObject temp;


    private void Start()
    {
        Vector3 spawnPosition = new Vector3();
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.x = Random.Range(- 2, 2);
            spawnPosition.y += Random.Range(minY, maxY); //사이의 값만 생성.
            temp = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            temp.transform.parent = this.gameObject.transform;
        }
    }

}
/*
private void Awake()
{
    var splinter = platformPrefab.GetComponentInChildren<Sprite>();
    animator = splinter.GetComponent<Animator>();
}
    private void Update()
    {
        playerPos = player.transform.position.y;
        RunSplinterAnim();
    }
    void RunSplinterAnim()
    {
        int x = Random.Range(0, 100);
        if (x < 100 && x > 70)
        {
            if (playerPos < temp.transform.position.y && temp.transform.position.y < playerPos)
            {
                animator.SetTrigger("splintTrigger");// "파라미터이름", 바꿀 값.
            }

        }
    }
*/