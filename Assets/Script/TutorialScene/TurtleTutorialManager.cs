using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleTutorialManager : MonoBehaviour
{
    public GameObject[] StartExplain = new GameObject[2];
    public GameObject TurtleItemPanel, stageCutton, EndExplain;
    public GameObject CatObj, nextButton, GookPanel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TurtleExplainCoroutine");
    }

    IEnumerator TurtleExplainCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        StartExplain[0].SetActive(true);
        yield return new WaitForSeconds(2f);
        StartExplain[0].SetActive(false);
        StartExplain[1].SetActive(true);
        yield return new WaitForSeconds(3f);
        StartExplain[1].SetActive(false);

        CatObj.SetActive(false);
        CatObj.SetActive(true);
        stageCutton.GetComponent<Animation>().Play("CuttonUp"); //커튼 올리기
        yield return new WaitForSeconds(0.125f);
        TurtleItemPanel.SetActive(true); //거북이 떨어지게 시작하기
    }

    public void End()
    {
        StartCoroutine("EndCoroutine");
    }

    IEnumerator EndCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        EndExplain.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        nextButton.SetActive(true);
    }

    public void NextButtonClicked()
    {
        GookPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
