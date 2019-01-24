using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempButton : MonoBehaviour
{
    public GameObject LuckyCatPop;
    public GameObject me;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1440, 2560, true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LuckyCatPopUp()
    {
        LuckyCatPop.SetActive(true);
    }
}
