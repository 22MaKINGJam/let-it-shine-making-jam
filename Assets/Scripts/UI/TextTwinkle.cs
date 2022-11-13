using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTwinkle : MonoBehaviour
{
    Text flashingText;
    string ogText;
    // Start is called before the first frame update
    void Start()
    {
        flashingText = GetComponent<Text>();
        ogText = flashingText.text;
        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        while (true)
        {
            flashingText.text = "";
            yield return new WaitForSeconds(0.5f);
            flashingText.text = ogText;
            yield return new WaitForSeconds(0.5f);
        }
    }


}