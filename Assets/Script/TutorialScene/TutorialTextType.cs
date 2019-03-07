using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTextType : MonoBehaviour
{
    public readonly static float TimePerALetter = 0.05f;
    public bool isFinish;
    public float totaltime;

    private String message;
    private Text textObject;

    void Start()
    {
        isFinish = false;
        textObject = gameObject.GetComponent<Text>();
        message = textObject.text;
        totaltime = TimePerALetter * message.Length; //총 걸리는 시간 저장
        textObject.text = "";
        StartCoroutine("TextTyping");
    }

    IEnumerator TextTyping()
    {
        for (int i = 1; i <= message.Length; i++)
        {
            yield return new WaitForSeconds(TimePerALetter);
            textObject.text = message.Substring(0, i);
        }
       isFinish = true;
    }
}
