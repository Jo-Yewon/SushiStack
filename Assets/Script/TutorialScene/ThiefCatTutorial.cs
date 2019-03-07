using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThiefCatTutorial : MonoBehaviour
{
    public GameObject ThiefCatObj;
    public GameObject[] Explain1 = new GameObject[2], EndExplain= new GameObject[2];
    public GameObject TheifSucceedPop;
    public GameObject CatSoundObj, ThiefCatCryObj;
    public GameObject NextButton;
    public GameObject TurtlePanel;


    private int CatClickTime;
    
    void Start()
    {
        CatClickTime = 0;
        StartCoroutine("Coroutine1");
    }

    IEnumerator Coroutine1()
    {
        yield return new WaitForSeconds(0.5f);
        ThiefCatObj.GetComponent<Animation>().Play("ThiefCatUp"); //고양이 올라오기
        CatSoundObj.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.4f);

        //도둑고양이 설명 시작
        yield return new WaitForSeconds(0.5f);
        Explain1[0].SetActive(true);
        yield return new WaitForSeconds(2f);
        Explain1[0].SetActive(false);
        Explain1[1].SetActive(true); //도둑고양이를 마구 클릭하세요~~
        yield return new WaitForSeconds(2f);

        ThiefCatObj.GetComponent<TheifCat>().enabled = true; //고양이 움직이도록
        ThiefCatObj.GetComponent<Button>().interactable = true; //이때부터 고양이 클릭 되도록

    }

    public void ThiefCatClicked()
    {
        CatClickTime++;
        if (CatClickTime == 10)
        {
            ThiefCatObj.GetComponent<TheifCat>().enabled = false;//도둑고양이 움직이는거 멈추기

            StartCoroutine("SucceddCoroutine");
        }
    }

    IEnumerator SucceddCoroutine()
    {
        yield return new WaitForSeconds(3f);

        //10번 클릭하면 다음 과정으로
        ThiefCatObj.GetComponent<Button>().interactable = false; //클릭도 안되도록
        Explain1[1].SetActive(false); //자막 없애기
        TheifSucceedPop.SetActive(true); //성공 메세지 띄우기
        //고양이 울도록
        ThiefCatObj.GetComponent<Animation>().Play("ThiefCatCry");
        ThiefCatCryObj.GetComponent<AudioSource>().Play(); //우는 고양이 소리
        yield return new WaitForSeconds(ThiefCatObj.GetComponent<Animation>()["ThiefCatCry"].length);

        //성공 후 설명
        EndExplain[0].SetActive(true);
        yield return new WaitForSeconds(2f);
        EndExplain[0].SetActive(false);
        EndExplain[1].SetActive(true); //도둑고양이를 마구 클릭하세요~~
        yield return new WaitForSeconds(2f);

        //고양이 내려가기
        ThiefCatObj.GetComponent<Animation>().Play("ThiefCatDown");
        yield return new WaitForSeconds(ThiefCatObj.GetComponent<Animation>()["ThiefCatDown"].length/2);
        TheifSucceedPop.SetActive(false);

        //다음 버튼 보이게 하기
        NextButton.SetActive(true);
    }

    public void NextButtonClicked()
    {
        TurtlePanel.SetActive(true); //거북이 듀토리얼로 넘어가기
        gameObject.SetActive(false);
    }
}
