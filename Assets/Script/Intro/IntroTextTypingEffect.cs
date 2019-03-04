using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroTextTypingEffect : MonoBehaviour
{
    public readonly static float TimePerALetter = 0.05f;
    public GameObject IntroManagerObject;

    private IntroManager_Re MyIntroManager;
    private String message;
    private Text textObject;
    private Touch tempTouchs;

    // Start is called before the first frame update
    void Start()
    {
        textObject = gameObject.GetComponent<Text>();
        message = textObject.text;
        textObject.text = "";
        MyIntroManager = IntroManagerObject.GetComponent<IntroManager_Re>();
        StartCoroutine("TextTyping");
    }

    public void Update()
    {
        if (Input.touchCount > 0)
        {
            tempTouchs = Input.GetTouch(0);
            if (tempTouchs.phase == TouchPhase.Ended)
            {
                StopCoroutine("TextTyping"); //타이핑 멈추기
                textObject.text = message; //자막 전체 바로 띄우기
                MyIntroManager.isTypingSkip_re = true;
                this.enabled = true; //이 스크립트 떼버리기.
            }
        }
    }

    IEnumerator TextTyping()
    {
        for(int i = 1; i <= message.Length; i++)
        {
            yield return new WaitForSeconds(TimePerALetter);
            textObject.text = message.Substring(0, i);
        }
        MyIntroManager.isTypingSkip_re = true;
    }
}
