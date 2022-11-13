using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2PlatformGenerator : MonoBehaviour
{
    public GameObject platform2Prefab;
    public GameObject candy;

    public float minY = .7f;
    public float maxY = 1.8f;
    GameObject temp;
    public int numberToCreate;
    private Platforms[] platforms;

    float y = 0;

    void Start()
    {

        CreateItemInit();
    }

    void CreateItemInit()
    {
        platforms = new Platforms[numberToCreate];
        for (int i = 0; i < numberToCreate; i++)
        {
            int j = Random.Range(0, 1);
            float x = Random.Range(-2, +2);
            y += Random.Range(minY, maxY);
            if(i % 5 == 1)
            {
                Vector2 creatingPoint = new Vector2(x, y);
                temp = Instantiate(candy, creatingPoint, Quaternion.identity);
            }
            else
                platforms[i] = CreateItemPosition(x, y, 2).GetComponent<Platforms>();
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
