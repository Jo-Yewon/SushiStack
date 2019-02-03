using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartTextLoadManager : MonoBehaviour
{
    public GameObject DataLoadText;
    public GameObject ScreenClickText;
  
    void Start()
    {
        StartCoroutine("TextChangeCoroutine");
    }

    IEnumerator TextChangeCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        DataLoadText.SetActive(false);
        ScreenClickText.SetActive(true);
    }
}
