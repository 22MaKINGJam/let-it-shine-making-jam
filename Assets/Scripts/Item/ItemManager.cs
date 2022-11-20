using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject player;
    public RuntimeAnimatorController cookiePlayer;

    public GameObject ItemEffectPopup;
    public string[] ItemEffectString;

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
            // 선물 아이템 확률 조정. 
            if(rand < giftPercentage && range == itemNumber)
            {
                temp.GetComponent<Item>().SetSprite(itemNumber - 1);
            }
            else
            {
                temp.GetComponent<Item>().SetSprite(Random.Range(0, itemNumber - 1));
            }
        }
        return temp;
    }


    public void EffectGinger()
    {
        // 쉴드
        GameObject.Find("DisturbanceManager").GetComponent<DisturbanceManager>().StartShield();
        ChangePlayer(cookiePlayer);

        if (IsInvoking("ShieldFalse") || IsInvoking("RealEndShield"))
        {
            Debug.Log("실행중이던 쉴드 멈춤");
            CancelInvoke("ShieldFalse");
            CancelInvoke("RealEndShield");
        }
        Debug.Log("다시 쉴드 시작");
        Invoke("ShieldFalse", shieldTime);
    }

    public void ChangePlayer(RuntimeAnimatorController obj)
    {
        // 캐릭터 애니메이션 바꾸기 (진저쿠키 입히기)
        StartCoroutine(ChangingCharacter(obj));
    }


    IEnumerator ChangingCharacter(RuntimeAnimatorController newAnimation)
    {
        int num = 2;
        while (num-- > 0)
        {
            player.GetComponent<SpriteRenderer>().color = new Color(0f,0f,0f,0f);
            yield return new WaitForSeconds(0.2f);
            player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.2f);
        }

        // 애니메이션 변경
        player.GetComponent<Animator>().runtimeAnimatorController = newAnimation;
    }

    public void EffectCandy()
    {
        // 점프 길이 n만큼 증가 (점프 force 증가)
        JumpFast();
        Invoke("JumpOrigin", shieldTime);
    }

    public void ItemPopupActive(int idx)
    {
        ItemEffectPopup.transform.GetChild(0).GetComponent<Text>().text = ItemEffectString[idx];
        ItemEffectPopup.SetActive(true);
        Invoke("RemovePopup", 1f);
    }

    void RemovePopup()
    {
        ItemEffectPopup.SetActive(false);
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
        Debug.Log("속도 빨라짐!");
        player.GetComponent<PlayerDesktop>().jumpPower *= jumpPowerUp;
        player.GetComponent<Player>().jumpPower *= jumpPowerUp;
    }


    void JumpOrigin()
    {
        Debug.Log("원래 속도 돌아옴!");
        player.GetComponent<PlayerDesktop>().jumpPower /= jumpPowerUp;
        player.GetComponent<Player>().jumpPower /= jumpPowerUp;
    }
}
