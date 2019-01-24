using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QMainScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
