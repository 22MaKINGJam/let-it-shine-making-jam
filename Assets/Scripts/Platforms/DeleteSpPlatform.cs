using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSpPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("기본 플랫폼과 겹침");
            Destroy(this.gameObject);
        }
    }
}
