using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheifCat : MonoBehaviour
{
    public static int touchCount;

    private Vector2 thiefCatOffsetMin, thiefCatOffsetMax;

    void OnEnable()
    {
        touchCount = 0;
        StartCoroutine("ThiefCatMoveCoroutine");
    }

    IEnumerator ThiefCatMoveCoroutine()
    {
        for(int i = 0; i < 25; i++)
        {
            yield return new WaitForSeconds(0.2f);
            thiefCatOffsetMin = gameObject.GetComponent<RectTransform>().offsetMin;
            thiefCatOffsetMax = gameObject.GetComponent<RectTransform>().offsetMax;
            thiefCatOffsetMin.x= Random.Range(0f, 602f);
            thiefCatOffsetMax.x = thiefCatOffsetMin.x-602f;
            gameObject.GetComponent<RectTransform>().offsetMin = thiefCatOffsetMin;
            gameObject.GetComponent<RectTransform>().offsetMax = thiefCatOffsetMax;
        }
    }

    public void TheifCatClicked()
    {
        touchCount++;
    }
}
