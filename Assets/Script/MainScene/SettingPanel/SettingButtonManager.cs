using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButtonManager : MonoBehaviour
{
    public GameObject warningPanel;
    public GameObject achievementsObject;

    public void YesClicked()
    {
        PlayerDataLoad.playerdata = new PlayerDataLoad.PlayerData();
        PlayerDataLoad.SaveData();

        achievementsObject.SetActive(false);
        achievementsObject.SetActive(true);

        warningPanel.SetActive(false);
    }

    public void NoClicked()
    {
        warningPanel.SetActive(false);
    }
}
