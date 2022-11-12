using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject itemPrefab;

    public int itemCount;
    public float minX, maxX, minY, maxY;
    public float minIntervalY, maxIntervalY;

    // 아이템 효과관련
    public float shieldTime;
    public float jumpPowerUp;
    public float giftPercentage;

    public GameObject SuperJumpPopup;

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
            int rand = Random.Range(0, 100);
            if(rand < giftPercentage && range == itemNumber)
            {
                temp.GetComponent<Item>().SetSprite(itemNumber - 1);
            }
            else
            {
                temp.GetComponent<Item>().SetSprite(Random.Range(0, itemNumber - 2));
            }
        }
        return temp;
    }


    public void EffectGinger()
    {
        // 쉴드
        GameObject.Find("DisturbanceManager").GetComponent<DisturbanceManager>().StartShield();
        // 캐릭터 애니메이션 바꾸기 (진저쿠키 입히기)
        Invoke("ShieldFalse", shieldTime);
    }

    public void EffectCandy()
    {
        // 점프 길이 n만큼 증가 (점프 force 증가)
        JumpFast();
        Invoke("JumpOrigin", shieldTime);
    }

    public void GetSuperJump()
    {
        SuperJumpPopup.SetActive(true);
    }

    void ShieldFalse()
    {
        GameObject.Find("DisturbanceManager").GetComponent<DisturbanceManager>().EndShield();
    }


    void JumpFast()
    {
        GameObject.Find("Player").GetComponent<PlayerDesktop>().jumpPower *= jumpPowerUp;
        GameObject.Find("Player").GetComponent<Player>().jumpPower *= jumpPowerUp;
    }


    void JumpOrigin()
    {
        Debug.Log("원래 속도 돌아옴!");
        GameObject.Find("Player").GetComponent<PlayerDesktop>().jumpPower /= jumpPowerUp;
        GameObject.Find("Player").GetComponent<Player>().jumpPower /= jumpPowerUp;
    }
}
