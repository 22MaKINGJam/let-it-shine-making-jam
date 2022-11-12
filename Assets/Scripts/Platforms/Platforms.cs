using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Platforms : MonoBehaviour
{

    // 0: cookie, 1: candy, 2: cheeze, 3: gift 
    public Sprite[] sprites;
    private int number;
    private float x, y;

    public void SetSprite(int idx)
    {
        number = idx;
        x = transform.position.x;
        y = transform.position.y;
        GetComponent<SpriteRenderer>().sprite = sprites[idx];
    }


    //public void ItemEffect(int idx)
    //{
    //    switch (idx)
    //    {
    //        case -1: // 슈퍼점프
    //            OnDeleteObject();
    //            break;
    //        case 0:
    //            GameObject.Find("ItemManager").GetComponent<ItemManager>().EffectGinger();
    //            GameObject.Find("ginobject").GetComponent<Ginscore>().GetScore();//1만큼 개수 증가
    //            OnDeleteObject();
    //            break;
    //        case 1:
    //            GameObject.Find("ItemManager").GetComponent<ItemManager>().EffectCandy();
    //            GameObject.Find("canobject").GetComponent<Canscore>().GetScore();//1만큼 개수 증가
    //            OnDeleteObject();
    //            break;
    //        case 2:
    //            // 점수 up
    //            GameObject.Find("cheobject").GetComponent<Chescore>().GetScore();//1만큼 개수 증가
    //            GameObject.Find("mainobject").GetComponent<Score>().GetScore();//1만큼 개수 증가
    //            OnDeleteObject();
    //            break;
    //        case 3:
    //            // 랜덤으로 아이템 나오게
    //            // 약간 선물상자 뜯어지는 애니메이션
    //            // 새로운 아이템
    //            StartCoroutine(NewItem());
    //            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    //            break;
    //    }
    //}

    //IEnumerator NewItem()
    //{
    //    yield return new WaitForSeconds(1f);

    //    // 0.1% 확률로 슈퍼점프 아이템!
    //    int rand = Random.Range(0, 100);
    //    bool isSuperJump = false;
    //    if (rand < superJumpPercentage)
    //    {
    //        isSuperJump = true;
    //    }

    //    GameObject temp = GameObject.Find("PlatformGenerator").GetComponent<Stage2PlatformGenerator>().CreateItemPosition(x, y, sprites.Length - 1, isSuperJump);
    //    Platform newplat = temp.GetComponent<Platform>();
    //}

    //public float GetX()
    //{
    //    return x;
    //}

    //public float GetY()
    //{
    //    return y;
    //}

    //public int GetNumber()
    //{
    //    return number;
    //}

    //public void SetSprite(int idx)
    //{
    //    number = idx;
    //    x = transform.position.x;
    //    y = transform.position.y;
    //    GetComponent<SpriteRenderer>().sprite = sprites[idx];
    //}


    //public void SetSuperJump()
    //{
    //    number = -1;
    //    x = transform.position.x;
    //    y = transform.position.y;
    //    GetComponent<SpriteRenderer>().sprite = superJump;
    //}

    //public void OnDeleteObject()
    //{
    //    Destroy(gameObject);
    //}
}
