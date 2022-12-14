using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothSpeed = .3f;
    private Vector3 currentVelocity;
    void LateUpdate()
    {
        if (GameObject.FindWithTag("Player").transform.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, GameObject.FindWithTag("Player").transform.position.y, transform.position.z);
            transform.position = newPos;
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, smoothSpeed * Time.deltaTime);
        }
    }
}
