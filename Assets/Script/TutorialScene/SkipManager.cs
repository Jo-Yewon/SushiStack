using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipManager : MonoBehaviour
{
    public void SkipClicked()
    {
        SceneManager.LoadScene("MainScene");
    }
}
