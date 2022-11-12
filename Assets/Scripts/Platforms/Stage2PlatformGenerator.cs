using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2PlatformGenerator : MonoBehaviour
{
    public GameObject platform2Prefab;

    public float minY = .7f;
    public float maxY = 1.8f;
    GameObject temp;
    public int numberToCreate;
    private Platforms[] platforms;
    private int kindOfplatforms = 3;
    float y;

    void Start()
    {
        kindOfplatforms = platform2Prefab.GetComponent<Platforms>().sprites.Length;
        CreateItemInit();
    }

    void CreateItemInit()
    {
        platforms = new Platforms[numberToCreate];
        for (int i = 0; i < numberToCreate; i++)
        {
            int j = Random.Range(0, 2);
            float x = Random.Range(-2, +2);
            y += Random.Range(minY, maxY);
            platforms[i] = CreateItemPosition(x, y, kindOfplatforms).GetComponent<Platforms>();
        }
    }

    public GameObject CreateItemPosition(float x, float y, int range)
    {
        Vector2 creatingPoint = new Vector2(x, y);
        GameObject temp = null;
        while (temp == null)
        {
            temp = Instantiate(platform2Prefab, creatingPoint, Quaternion.identity);
        }
        temp.transform.parent = this.gameObject.transform;
        temp.GetComponent<Platforms>().SetSprite(Random.Range(0, range));
        return temp;
    }

}
