using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_SplintPlatGenerator : MonoBehaviour
{
    public GameObject st2PlatformPrefab;
    public int numberOfSplinterPlatforms;
    public float levelWidth = 3f;
    public float minY = .8f;
    public float maxY = 3.0f;

    GameObject temp;

    private void Start()
    {
        Vector3 spawnPosition = gameObject.transform.GetChild(0).position;
        for (int i = 0; i < numberOfSplinterPlatforms; i++)
        {
            spawnPosition.x = Random.Range(-3.5f,0.5f);
            spawnPosition.y += Random.Range(minY, maxY);
            temp = Instantiate(st2PlatformPrefab, spawnPosition, Quaternion.identity);

            temp.transform.parent = this.gameObject.transform;
        }
    }
}
