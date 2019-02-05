using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InSettingButtonManager : MonoBehaviour
{
    public GameObject warningPanel;
    public GameObject settingPanel;

    public void BackButtonClicked()
    {
        settingPanel.SetActive(false);
    }
    public void dataReset()
    {
        warningPanel.SetActive(true);
    }
}
