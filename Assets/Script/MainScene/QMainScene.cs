using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QMainScene : MonoBehaviour
{
    public void GameStartButtonClicked()
    {
        Debug.Log("GameStartButtonClick");
        SceneManager.LoadScene("SampleScene");
    }

    public void StoreButtonClicked()
    {

    }

    public void CollectionButtonClicked()
    {

    }

    public void SettingButtonClicked()
    {

    }

    public void NameEditButtonClicked()
    {

    }
}
