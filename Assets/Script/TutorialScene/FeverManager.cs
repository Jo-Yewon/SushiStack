using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverManager : MonoBehaviour
{
    public GameObject StartExplain;
    public GameObject FeverItemPanel, stageCutton, CatObj;
    public GameObject nextButton, EndPanel, EndExplain;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FeverExplainCoroutine");
    }

    IEnumerator FeverExplainCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        StartExplain.SetActive(true);
        yield return new WaitForSeconds(3f);
        StartExplain.SetActive(false);

        CatObj.GetComponent<TDragCat>().CatInit();
        stageCutton.GetComponent<Animation>().Play("CuttonUp"); //커튼 올리기
        yield return new WaitForSeconds(0.125f);

        FeverItemPanel.SetActive(true); //무지개접시 떨어지게 시작하기
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
        EndPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
