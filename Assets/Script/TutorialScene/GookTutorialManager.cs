using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GookTutorialManager : MonoBehaviour
{
    public GameObject explain1, stageCutton, CatObj;
    public GameObject GookItemPanel;
    public GameObject EndExplain1, EndExplain2, nextButton, FeverPanel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartExplain");
    }

    IEnumerator StartExplain()
    {
        yield return new WaitForSeconds(0.8f);
        explain1.SetActive(true);
        yield return new WaitForSeconds(2f);
        explain1.SetActive(false);
        CatObj.GetComponent<TDragCat>().CatInit(); //고양이 초기화

        stageCutton.GetComponent<Animation>().Play("CuttonUp"); //커튼 올리기
        yield return new WaitForSeconds(0.125f);
        GookItemPanel.SetActive(true);
    }

    public void End()
    {
        StartCoroutine("EndCoroutine");
    }

    IEnumerator EndCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        EndExplain1.SetActive(true);
        yield return new WaitForSeconds(3f);
        EndExplain1.SetActive(false);
        EndExplain2.SetActive(true);
        yield return new WaitForSeconds(2f);
        nextButton.SetActive(true);
    }

    public void NextButtonClicked()
    {
        FeverPanel.SetActive(true);
        gameObject.SetActive(false);
    }


}
