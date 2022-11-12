using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disturbance : MonoBehaviour
{
    private void Update()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        float cameraSize = mainCamera.GetComponent<Camera>().orthographicSize;

        // 카메라 범위 벗어나면 오브젝트 지우기
        if(mainCamera.transform.position.y - cameraSize > transform.position.y)
        {
            OnDelete();
        }
    }

    public void OnDelete()
    {
        GameObject.Find("DisturbanceManager").GetComponent<DisturbanceManager>().isExist = false;
        if (gameObject)
        {
            Destroy(gameObject);
        }
    }

}
