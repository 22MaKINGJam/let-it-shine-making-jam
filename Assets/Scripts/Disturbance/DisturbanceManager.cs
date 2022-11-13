using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisturbanceManager : MonoBehaviour
{
    public GameObject Player_;

    // 방해요소 프리팹
    public GameObject [] disturbancPrefab;

    // 몇 초에 한 번씩 50% 확률로 나오도록
    public float interval;
    public float percentage;

    public float minX, maxX;

    // 방해 요소 개수
    public int cnt; // 0: 오너먼트, 1: 전구 설정

    // 오너먼트 생기는 위치 최소, 최대
    public float minItervalY, maxIntervalY;

    [HideInInspector]
    public bool isDisturbance = false;
    [HideInInspector]
    public bool isExist = false; // 동시에 2개 방해 요소는 안나오도록

    int disturbanceIdx = 0;
    GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        isDisturbance = true;
        StartCoroutine(CreateDisturbance());
    }

    IEnumerator CreateDisturbance()
    {
        yield return new WaitForSeconds(interval);

        while (isDisturbance)
        {
            int rand = Random.Range(0, 100);
            if (rand < percentage && !isExist) // 방해 요소 생성
            {
                isExist = true;
                //int disturbance = Random.Range(0, cnt);
                int disturbance = 1;
                disturbanceIdx = disturbance;
                GameObject temp = null;
                while(temp == null)
                {
                    temp = SetDisturbance(disturbance);
                }
            }
            yield return new WaitForSeconds(interval);
        }
       
    }


    GameObject SetDisturbance(int idx)
    {
        // 오브젝트 생성. 플레이어 위치 좌표 얻어와서 그 위로 해야할듯! +2 ~  5 이내
        float playerY = GameObject.FindWithTag("Player").transform.position.y;
        float rand = Random.Range(minItervalY, maxIntervalY);

        float newY = playerY + rand;
        float x = Random.Range(minX, maxX);
        Vector2 creatingPoint = new Vector2(x, newY);

        // 방해 요소 초기 세팅
        temp = Instantiate(disturbancPrefab[idx], creatingPoint, Quaternion.identity);
        temp.transform.parent = this.gameObject.transform;

        return temp;
    }

    public void TempDelete()
    {
        temp.GetComponent<Disturbance>().OnDelete();
    }

    public void StartShield()
    {
        // 오너먼트는 통과되게
        // 전구 통과되게+ 스크립트 비활성화
        temp.GetComponent<BoxCollider2D>().isTrigger = true;

        if (disturbanceIdx == 1)
        {
            temp.GetComponent<Bulb>().enabled = false;
        }

        // 함정 스크립트 비활성화
    }


    public void EndShield()
    {
        temp.GetComponent<BoxCollider2D>().isTrigger = false;

        if (disturbanceIdx == 1)
        {
            temp.GetComponent<Bulb>().enabled = true;
        }

        GameObject.Find("ItemManager").GetComponent<ItemManager>().ChangePlayer(Player_);
    }
}

