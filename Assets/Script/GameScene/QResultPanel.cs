using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QResultPanel : MonoBehaviour
{
    public GameObject redPlateText, greenPlateText, bluePlateText;
    public GameObject GuestScoreText, ThiefScoreText;
    public GameObject TimeManager;
    // Start is called before the first frame update

    void OnEnable()
    {
        //점수띄우기
        //최고점수 비교후 갱신   
        //갱신되면 칭호도 같이 갱신
        //갱신되면 컬렉션도 열기

        //접시 개수 표시하기
        redPlateText.GetComponent<Text>().text = RedPlate.redPlateNum.ToString();
        greenPlateText.GetComponent<Text>().text = GreenPlate.greenPlateNum.ToString();
        bluePlateText.GetComponent<Text>().text = BluePlate.bluePlateNum.ToString();

        //손님 수, 도둑고양이 성공수 표시
        GuestScoreText.GetComponent<Text>().text = Timer30s.GuestScore.ToString();
        ThiefScoreText.GetComponent<Text>().text = Timer30s.ThiefCatCount.ToString();
    }

    public void RetryButtonClick()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<BGMScript>().ButtonClickedSoundPlay();
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void HomeButtonClick()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<BGMScript>().ButtonClickedSoundPlay();
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }

}
