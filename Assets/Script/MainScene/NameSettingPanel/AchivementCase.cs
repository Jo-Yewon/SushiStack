using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementCase : MonoBehaviour
{
    public GameObject leftQuote,rightQuote;
    private Vector3 Position,leftPosition,rightPosition;

    public void Start()
    {
        leftPosition = leftQuote.transform.position;
        rightPosition = rightQuote.transform.position;
    }

    public void ResizeQuotes()
    {
        leftPosition.x = -(GetComponent<RectTransform>().rect.size.x / 2/100);
        leftQuote.transform.position = leftPosition;
        rightPosition.x = GetComponent<RectTransform>().rect.size.x / 2/100;
        rightQuote.transform.position = rightPosition;

    }
}
