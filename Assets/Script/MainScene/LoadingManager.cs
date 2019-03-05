using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public GameObject []TextArray = new GameObject[4];

    private AsyncOperation op;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadingTextShowCoroutine");
        
        //신 비동기로 호출 시작
        op = SceneManager.LoadSceneAsync("SampleScene");
        op.allowSceneActivation = false;

        Invoke("SampleSceneShow", 4f); //4초 동안 로딩 되기를 기다린 후...
    }

    void SampleSceneShow()
    {
        op.allowSceneActivation = true; //보이도록
    }

    IEnumerator LoadingTextShowCoroutine()
    {
        for(int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.8f);
            gameObject.GetComponent<AudioSource>().Play();
            TextArray[i].SetActive(true);
        }
    }
}
