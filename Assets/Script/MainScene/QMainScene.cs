using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QMainScene : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject StoreInfoPanel;

    public void GameStartButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StoreButtonClicked()
    {
        SceneManager.LoadScene("StoreScene");
    }

    public void CollectionButtonClicked()
    {
        SceneManager.LoadScene("CollectionScene");
    }

    public void SettingButtonClicked()
    {
        SettingPanel.SetActive(true);
    }

    public void NameEditButtonClicked()
    {
        StoreInfoPanel.SetActive(true);
    }
}
