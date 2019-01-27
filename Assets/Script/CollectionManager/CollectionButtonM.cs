using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectionButtonM : MonoBehaviour
{
    public void BackButtonClicked()
    {
        SceneManager.LoadScene("MainScene");
    }
}
