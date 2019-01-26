using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckyCatManager : MonoBehaviour
{
    public GameObject QLuckyCatNum;
    public GameObject QResultPop;
    public GameObject QtempPanel;
    public GameObject Timer;

    private int GameOverTime; //게임오버 회수가 늘면 행운의 고양이도 많이 사용
    private int NeedLuckyCat;

    void Awake()
    {
        GameOverTime = 0;
        NeedLuckyCat = 1;
    }
    // Start is called before the first frame update

    void OnEnable()
    {
        Time.timeScale = 0;
        NeedLuckyCat += GameOverTime++;
        QLuckyCatNum.GetComponent<Text>().text = NeedLuckyCat.ToString();
        //이 팝업이 뜰때는 게임을 일시중지
    }

    public void LuckyCatYes()
    {
        //Yes 누르면 행운의 고양이 아이템 사용된 후에, 게임을 계속 진행할 수 있도록
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
