using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QResultPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //점수띄우기
        //최고점수 비교후 갱신
        //갱신되면 칭호도 같이 갱신
        //갱신되면 컬렉션도 열기
    }
    public void RetryButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void HomeButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }

}
