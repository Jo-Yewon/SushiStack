using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterEffect : MonoBehaviour
{

    void OnEnable()
    {
        gameObject.GetComponent<Animation>().Play();
        gameObject.SetActive(false);
    }
}
