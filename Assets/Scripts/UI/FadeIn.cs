using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public GameObject obj;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        if (obj.GetComponent<Text>())
        {
            StartCoroutine(FadeInText(obj.GetComponent<Text>()));
        }
        else if(obj.GetComponent<Image>())
        {
            StartCoroutine(FadeInImage(obj.GetComponent<Image>()));
        }
    }

    IEnumerator FadeInText(Text background)  // 알파값 0 -> 1
    {
        background.color = new Color(background.color.r, background.color.g, background.color.b, 0);
        while (background.color.a < 1.0f)
        {
            background.color = new Color(background.color.r, background.color.g, background.color.b, background.color.a + Time.deltaTime * speed);
            yield return null;
        }
    }

    IEnumerator FadeInImage(Image background)  // 알파값 0 -> 1
    {
        background.color = new Color(background.color.r, background.color.g, background.color.b, 0);
        while (background.color.a < 1.0f)
        {
            background.color = new Color(background.color.r, background.color.g, background.color.b, background.color.a + Time.deltaTime * speed);
            yield return null;
        }
    }
}
