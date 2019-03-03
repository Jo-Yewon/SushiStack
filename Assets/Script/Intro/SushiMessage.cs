using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SushiMessage : MonoBehaviour
{
    private readonly static float TWINKLE_INTERVAL1 = 0.5f, TWINKLE_INTERVAL2=0.4f;
    private Color transparent,original;

    void Start()
    {
        original = gameObject.GetComponent<Image>().color;
        transparent = original;
        transparent.a = 0.8f;
        StartCoroutine("TwinkleCoroutine");
    }

    IEnumerator TwinkleCoroutine()
    {
        gameObject.GetComponent<Image>().color = transparent;
        yield return new WaitForSeconds(TWINKLE_INTERVAL1);
        gameObject.GetComponent<Image>().color = original;
        yield return new WaitForSeconds(TWINKLE_INTERVAL2);
        StartCoroutine("TwinkleCoroutine");
    }
}
