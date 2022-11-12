using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // 0: cookie, 1: candy, 2: cheeze, 3: gift 
    public Sprite[] sprites;
    private int number;
    private float x, y;

    // player item trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("플레이어! 삭제!");
            ItemEffect(number);
        }
        else if (collision.gameObject.tag == "Flatform")
        {
            Debug.Log("플랫폼 겹침! 삭제!");
            // 플랫폼이랑 겹치면 사라지게
            OnDeleteObject();
        }
    }

    public void ItemEffect(int idx)
    {
        switch (idx)
        {
            case 0:
                // 속도 n만큼 증가
                OnDeleteObject();
                break;
            case 1:
                // 점프 길이 n만큼 증가 (점프 force 증가)
                OnDeleteObject();
                break;
            case 2:
                // 점수 up
                OnDeleteObject();
                break;
            case 3:
                // 랜덤으로 아이템 나오게
                // 약간 선물상자 뜯어지는 애니메이션
                // 새로운 아이템
                StartCoroutine(NewItem());
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
                break;
        }
    }
    

    IEnumerator NewItem()
    {
        yield return new WaitForSeconds(1f);

        GameObject temp = GameObject.Find("ItemManager").GetComponent<ItemManager>().CreateItemPosition(x, y, sprites.Length - 1);
        Item newItem = temp.GetComponent<Item>();

        // 바로 사용 + 사라짐
        yield return new WaitForSeconds(1f);
        newItem.ItemEffect(newItem.GetNumber());
        OnDeleteObject();
    }

    public float GetX()
    {
        return x;
    }

    public float GetY()
    {
        return y;
    }

    public int GetNumber()
    {
        return number;
    }

    public void SetSprite(int idx)
    {
        number = idx;
        x = transform.position.x;
        y = transform.position.y;
        GetComponent<SpriteRenderer>().sprite = sprites[idx];
    }

    public void OnDeleteObject()
    {
        Destroy(gameObject);
    }
}
