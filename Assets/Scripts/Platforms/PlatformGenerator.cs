using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public int numberOfPlatforms;
    public float levelWidth = 3f;
    public float minY = .7f;
    public float maxY = 1.5f;

    GameObject temp;


    private void Start()
    {
        Vector3 spawnPosition = gameObject.transform.GetChild(0).position + new Vector3(0f, 1f, 0f);
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.x = Random.Range(- 2, 2);
            spawnPosition.y += Random.Range(minY, maxY); 
            temp = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            temp.transform.parent = this.gameObject.transform;
        }
    }

}