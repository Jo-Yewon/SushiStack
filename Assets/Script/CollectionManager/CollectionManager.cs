using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionManager : MonoBehaviour
{
    public GameObject green1000, green2000, blue4000, blue5000, red7000, red8000;

    private static Color unlockColor = new Color(0.4f, 0.4f, 0.4f); //아직 열리지 않은 스시 색

    void Start()
    {
        int sushiIndex = PlayerDataLoad.playerdata.AchievementIndex;

        if (sushiIndex < 8) UnlockSushi(red8000);
        if (sushiIndex < 7) UnlockSushi(red7000);
        if (sushiIndex < 5) UnlockSushi(blue5000);
        if (sushiIndex < 4) UnlockSushi(blue4000);
        if (sushiIndex < 2) UnlockSushi(green2000);
        if (sushiIndex < 1) UnlockSushi(green1000);
    }

    void UnlockSushi(GameObject sushi)
    {
        sushi.GetComponent<Image>().color = unlockColor; //스시 이미지 회색으로
        sushi.transform.GetChild(0).gameObject.SetActive(true); // 언락 기준 텍스트 활성화
    }
}
