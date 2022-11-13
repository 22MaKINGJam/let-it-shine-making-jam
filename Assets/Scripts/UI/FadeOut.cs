using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public GameObject obj;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        if (obj.GetComponent<Text>())
        {
            StartCoroutine(FadeOutText(obj.GetComponent<Text>()));
        }
        else if (obj.GetComponent<Image>())
        {
            StartCoroutine(FadeOutImage(obj.GetComponent<Image>()));
        }
    }

    IEnumerator FadeOutText(Text background)  // 알파값 1 -> 0
    {
        background.color = new Color(background.color.r, background.color.g, background.color.b, 1);

        while (background.color.a > 0.0f)
        {
            background.color = new Color(background.color.r, background.color.g, background.color.b, background.color.a - (Time.deltaTime * speed));
            yield return null;
        }
    }

    IEnumerator FadeOutImage(Image background)  // 알파값 1 -> 0
    {
        background.color = new Color(background.color.r, background.color.g, background.color.b, 1);

        while (background.color.a > 0.0f)
        {
            background.color = new Color(background.color.r, background.color.g, background.color.b, background.color.a - (Time.deltaTime * speed));
            yield return null;
        }
    }
}
