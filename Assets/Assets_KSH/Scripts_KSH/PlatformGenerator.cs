using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public Camera mainCamera;
    public GameObject player;
    public int numberOfPlatforms;
    public float levelWidth = 3f;
    public float minY = .4f;
    public float maxY = 1.5f;

    private void Start()
    {
        Vector3 spawnPosition = new Vector3();
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            //spawnPosition.x = Random.Range(player.transform.position.x - Screen.width/2, player.transform.position.x + Screen.width / 2);
            spawnPosition.x = Random.Range(player.transform.position.x - 2, player.transform.position.x + 2);
            spawnPosition.y += Random.Range(minY, maxY); //사이의 값만 생성.
            GameObject temp = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            temp.transform.parent = this.gameObject.transform;
        }
    }

}
