using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetPointSlider : MonoBehaviour {

    public Text pointAmount;

    public void PointAmount(float sliderPo)
    {
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "PointAmount", (int)sliderPo);
        PlayerPrefs.Save();
        pointAmount.text = ((int)sliderPo + 2).ToString();
    }
}
