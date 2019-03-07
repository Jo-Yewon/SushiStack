using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TLuckyCatManager : MonoBehaviour
{
    public GameObject[] LuckyCatExplainTextArr = new GameObject[3];
    public GameObject YesButton;
    public GameObject ThiefCatPanel;

    void OnEnable()
    {
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine("LuckyCatExplainCoroutine");
    }

    IEnumerator LuckyCatExplainCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        LuckyCatExplainTextArr[0].SetActive(true);
        yield return new WaitForSeconds(2f);
        LuckyCatExplainTextArr[0].SetActive(false);
        LuckyCatExplainTextArr[1].SetActive(true);
        yield return new WaitForSeconds(3f);
        LuckyCatExplainTextArr[1].SetActive(false);
        LuckyCatExplainTextArr[2].SetActive(true);
        yield return new WaitForSeconds(0.6f);

        YesButton.GetComponent<Button>().interactable = true; // 예스버튼 클릭할 수 있도록
    }

    public void LuckyCatYes()
    {
        ThiefCatPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
