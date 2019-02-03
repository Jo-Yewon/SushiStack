using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTypingEffect : MonoBehaviour
{
    public float TimePerALetter;

    private String message;
    private Text textObject;

    // Start is called before the first frame update
    void Start()
    {
        textObject = gameObject.GetComponent<Text>();
        message = textObject.text;
        textObject.text = "";
        StartCoroutine("TextTyping");
    }

    IEnumerator TextTyping()
    {
        for(int i = 1; i < message.Length; i++)
        {
            textObject.text = message.Substring(0, i);
            yield return new WaitForSeconds(TimePerALetter);
        }
    }
}
