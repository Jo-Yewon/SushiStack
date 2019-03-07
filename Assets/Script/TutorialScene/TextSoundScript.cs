using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSoundScript : MonoBehaviour
{
    void OnEnable()
    {
        GameObject.Find("TextSoundObj").GetComponent<AudioSource>().Play();
    }
}
