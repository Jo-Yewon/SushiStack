using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewSushiPanel : MonoBehaviour
{
    public GameObject NewAchieveText,SushiImageObject;
    public GameObject[] SushiImage = new GameObject[10];

    private readonly static int[] SushiUnlockInfo = { 1, 2, 4, 5, 7, 8 };

    void Awake()
    {
        //SushiImage 배열에 스시이미지 오브젝트 번호 맞추어 저장
        for (int i = 0; i < 6; i++)
            SushiImage[SushiUnlockInfo[i]] = SushiImageObject.transform.GetChild(i).gameObject;
    }

    void Update()
    {
        Time.timeScale = 1;
    }

    void OnEnable()
    {
        //새롭게 획득한 칭호 표시 //다수의 칭호를 동시에 획득시 가장 높은 칭호만 표시하기.
        NewAchieveText.GetComponent<Text>().text =
            PlayerDataLoad.PlayerData.AchievementString[PlayerDataLoad.playerdata.AchievementIndex];

        //Sushi 뜨는 것 시작
        StartCoroutine("SushiPopCoroutine");
    }

    IEnumerator SushiPopCoroutine()
    {
        int last = 0;

        for (int i = PlayerDataLoad.playerdata.LastAchievementIndex + 1; i <= PlayerDataLoad.playerdata.AchievementIndex; i++)
        {
            if (i == 3 || i == 6 || i == 9) continue;

            if (last != 0) SushiImage[last].SetActive(false);//예전에 띄워졌던 이미지는 없애기
            SushiImage[i].SetActive(true); //새로운 이미지
            //스시 나오는 이미지도 나오기.
            last = i;

            yield return new WaitForSeconds(1f); //1초 후에 다른 초밥 띄우기.
        }
    }

    public void OKClicked() //화면 누르면 다시 결과창으로 돌아가기
    {
        gameObject.SetActive(false);
    }
}
