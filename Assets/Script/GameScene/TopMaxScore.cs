using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopMaxScore : MonoBehaviour
{
    private static readonly int TWINKEL_TIME = 3;
    private static readonly float TWINKEL_MARGIN = 0.5f;
    private Color textColor,textTransparent;

    void OnEnable() //Max 표시가 깜박임(사용자의 주의 환기를 위하여)
    {
        textColor = gameObject.GetComponent<Text>().color;
        textTransparent = textColor;
        textTransparent.a = -0.5f;

        StartCoroutine("TwinkleCoroutine");
    }

    IEnumerator TwinkleCoroutine()
    {
        for(int i = 0; i < TWINKEL_TIME; i++)
        {
            yield return new WaitForSeconds(TWINKEL_MARGIN);
            gameObject.GetComponent<Text>().color = textTransparent;
            yield return new WaitForSeconds(0.2f);
            gameObject.GetComponent<Text>().color = textColor;
        }
    }
}


