using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultStory : MonoBehaviour
{
    private List<GameObject> storyImageList;

    // Start is called before the first frame update
    void Awake()
    {
        storyImageList = new List<GameObject>();
        for (int i = 0; i < gameObject.transform.childCount; i++)
            storyImageList.Add(gameObject.transform.GetChild(i).gameObject);
    }


    void OnEnable()
    {
        storyImageList[Random.Range(0, storyImageList.Count)].SetActive(true);
    }
}
