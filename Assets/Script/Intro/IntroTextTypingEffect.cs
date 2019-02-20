using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroTextTypingEffect : MonoBehaviour
{
    public float TimePerALetter;
    public GameObject IntroManagerObject;

    private IntroManager_Re MyIntroManager;
    private String message;
    private Text textObject;

    // Start is called before the first frame update
    void Start()
    {
        textObject = gameObject.GetComponent<Text>();
        message = textObject.text;
        textObject.text = "";
        StartCoroutine("TextTyping");
        MyIntroManager = IntroManagerObject.GetComponent<IntroManager_Re>();
    }

    public void Update()
    {
        if (Input.touchCount > 0)
        {
            StopCoroutine("TextTyping"); //타이핑 멈추기
            textObject.text = message; //자막 전체 바로 띄우기
            this.enabled = true; //이 스크립트 떼버리기.
        }
    }

    IEnumerator TextTyping()
    {
        for(int i = 1; i < message.Length; i++)
        {
            textObject.text = message.Substring(0, i);
            yield return new WaitForSeconds(TimePerALetter);
        }
        MyIntroManager.isTypingSkip_re = true;
    }
}
