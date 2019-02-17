using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectionButtonM : MonoBehaviour
{
    public void BackButtonClicked()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<BGMScript>().ButtonClickedSoundPlay();
        SceneManager.LoadScene("MainScene");
    }
}
