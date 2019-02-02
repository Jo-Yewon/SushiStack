using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLackText : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine("Disappear");
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
