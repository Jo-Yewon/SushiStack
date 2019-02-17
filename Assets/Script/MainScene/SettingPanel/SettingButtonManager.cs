using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButtonManager : MonoBehaviour
{
    public GameObject warningPanel;
    public GameObject achievementsObject;

    public void YesClicked()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<BGMScript>().ButtonClickedSoundPlay();

        PlayerDataLoad.playerdata = new PlayerDataLoad.PlayerData();
        PlayerDataLoad.SaveData();

        achievementsObject.SetActive(false);
        achievementsObject.SetActive(true);

        warningPanel.SetActive(false);
    }

    public void NoClicked()
    {
        GameObject.FindWithTag("SoundManager").GetComponent<BGMScript>().ButtonClickedSoundPlay();
        warningPanel.SetActive(false);
    }
}
