using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject itemPrefab;

    public int itemCount;
    public float minX, maxX, minY, maxY;
    public float minIntervalY, maxIntervalY;

    private Item[] items;
    private int itemNumber;

    private float currentY;

    // Start is called before the first frame update
    void Start()
    {
        currentY = minY;
        itemNumber = itemPrefab.GetComponent<Item>().sprites.Length;
        CreateItemInit();
    }

    void CreateItemInit()
    {
        items = new Item[itemCount];
        for(int i = 0; i < itemCount; i++)
        {
            float x = Random.Range(minX, maxX);
            float y = currentY + Random.Range(minIntervalY, maxIntervalY);
            currentY = y;

            items[i] = CreateItemPosition(x, y, itemNumber, false).GetComponent<Item>();
        }
    }

    public GameObject CreateItemPosition(float x, float y, int range, bool isSuperJump)
    {
        Vector2 creatingPoint = new Vector2(x, y);
        GameObject temp = null;
        while(temp == null)
        {
            temp = Instantiate(itemPrefab, creatingPoint, Quaternion.identity);
        }
        temp.transform.parent = this.gameObject.transform;

        if (isSuperJump)
        {
            temp.GetComponent<Item>().SetSuperJump();
        }
        else
        {
            temp.GetComponent<Item>().SetSprite(Random.Range(0, range));
        }
        return temp;
    }
}
