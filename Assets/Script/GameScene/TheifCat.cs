using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheifCat : MonoBehaviour
{
    public static int touchCount;

    private Vector2 thiefCatOffsetMin, thiefCatOffsetMax;

    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f; //투명한 부분만 클릭 되도록
    }

    void OnEnable()
    {
        touchCount = 0;
        StartCoroutine("ThiefCatMoveCoroutine");
    }

    IEnumerator ThiefCatMoveCoroutine() //도둑고양이가 0.2초 간격으로 좌우로 이동함.
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
