using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckyCatManager : MonoBehaviour
{
    public GameObject QLuckyCatNum;
    public GameObject QResultPop;
    public GameObject QtempPanel;
    public GameObject MyLuckyCatNum;

    private int GameOverTime; //게임오버 회수가 늘면 행운의 고양이도 많이 사용
    private int NeedLuckyCat;
    private Text QLuckyCatNumText;
    private Text MyLuckyCatNumText;

    void Awake()
    {
        GameOverTime = 0;
        NeedLuckyCat = 1;

        QLuckyCatNumText = QLuckyCatNum.GetComponent<Text>();
        MyLuckyCatNumText = MyLuckyCatNum.GetComponent<Text>();
    }
    // Start is called before the first frame update

    void OnEnable()
    {
        Time.timeScale = 0;
        NeedLuckyCat += GameOverTime++;

        //보유개수가 필요개수보다 작으면 바로 결과창으로
        if (PlayerDataLoad.playerdata.item_luckycat_num < NeedLuckyCat)
            LuckyCatNo();

        MyLuckyCatNumText.text = "(보유 : " + PlayerDataLoad.playerdata.item_luckycat_num + "개)";
        QLuckyCatNumText.text = NeedLuckyCat.ToString();
        //이 팝업이 뜰때는 게임을 일시중지
    }

    public void LuckyCatYes()
    {
        //Yes 누르면 행운의 고양이 아이템 사용된 후에, 게임을 계속 진행할 수 있도록

        PlayerDataLoad.playerdata.item_luckycat_num -= NeedLuckyCat;
        PlayerDataLoad.SaveData();//아이템 쓰고 데이터 저장

        Time.timeScale = 1;
        QtempPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void LuckyCatNo()
    {
        //No 누르면 게임 종료후 결과창 띄우기
        QResultPop.SetActive(true);
        gameObject.SetActive(false);
        // 주석을 추가합니다.
    }
}
