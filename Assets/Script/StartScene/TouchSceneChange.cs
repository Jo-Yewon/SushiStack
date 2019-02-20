using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchSceneChange : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
            if (PlayerDataLoad.isFirst) SceneManager.LoadScene("IntroScene"); //첫 접속 시에만 인트로 보여주기
            else SceneManager.LoadScene("MainScene"); //첫 접속 아닐 때는 바로 메인으로
    }
}
