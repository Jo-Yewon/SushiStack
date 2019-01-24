using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QGamePauseB : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject GamePausePanel;

    // Start is called before the first frame update
    void Start()
    {
        //버튼 배경은 클릭 되지 않도록.
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    public void GamePauseClick()
    {
        GamePausePanel.SetActive(true);
    }
}
