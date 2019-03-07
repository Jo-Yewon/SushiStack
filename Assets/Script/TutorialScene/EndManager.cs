using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public GameObject text1, text2, button1;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine("EndCoroutine");
    }

    IEnumerator EndCoroutine()
    {
        yield return new WaitForSeconds(1f);
        text1.SetActive(true);
        yield return new WaitForSeconds(1f);
        text2.SetActive(true);
        yield return new WaitForSeconds(1f);
        button1.SetActive(true);
    }

    public void EndButtonClicked()
    {
        SceneManager.LoadScene("MainScene");
    }

}
