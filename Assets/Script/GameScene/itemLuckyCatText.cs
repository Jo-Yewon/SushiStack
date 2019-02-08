using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemLuckyCatText : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Text>().text = PlayerDataLoad.playerdata.item_luckycat_num.ToString();
    }
}
