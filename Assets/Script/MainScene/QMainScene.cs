using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QMainScene : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject StoreInfoPanel;

    private AudioSource buttonClikedSound;

    void Start()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<BGMScript>().StartBGMPlay();
        buttonClikedSound = gameObject.GetComponent<AudioSource>();
    }

    public void GameStartButtonClicked()
    {
        buttonClikedSound.Play();
        //SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene("LoadingScene");
    }

    public void StoreButtonClicked()
    {
        buttonClikedSound.Play();
        SceneManager.LoadScene("StoreScene");
    }

    public void CollectionButtonClicked()
    {
        buttonClikedSound.Play();
        SceneManager.LoadScene("CollectionScene");
    }

    public void SettingButtonClicked()
    {
        buttonClikedSound.Play();
        SettingPanel.SetActive(true);
    }

    public void NameEditButtonClicked()
    {
        buttonClikedSound.Play();
        StoreInfoPanel.SetActive(true);
    }

    public void IntroButtonClicked()
    {
        buttonClikedSound.Play();
        SceneManager.LoadScene("IntroScene(Re)");
    }
}
