using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetPointSlider : MonoBehaviour {

    public Text pointAmount;
    public Slider sliderPoint;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("User_" + PlayerPrefs.GetString("User") + "PointAmount"))
        {
            sliderPoint.GetComponent<Slider>().value = 0;
            pointAmount.text = sliderPoint.GetComponent<Slider>().value + 2.ToString();

        }
        else
        {
            sliderPoint.GetComponent<Slider>().value = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "PointAmount");
            pointAmount.text = sliderPoint.GetComponent<Slider>().value + 2.ToString();

        }
    }

    public void PointAmount(float sliderPo)
    {
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "PointAmount", (int)sliderPo);
        PlayerPrefs.Save();
        pointAmount.text = ((int)sliderPo + 2).ToString();
    }
}
