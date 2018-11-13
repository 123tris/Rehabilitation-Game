using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBumperAndBoardSize : MonoBehaviour
{
    public GameObject sliderBumper;
    public GameObject sliderBoard;
    public GameObject sliderTime;
    public Text bumperAmount, boardAmount, timeAmount;


    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey("User_" + PlayerPrefs.GetString("User") + "MaxBumperAmount"))
        {
            sliderBoard.GetComponent<Slider>().value = 5;
            sliderBumper.GetComponent<Slider>().value = 7;
            sliderTime.GetComponent<Slider>().value = 5;
            bumperAmount.text = sliderBumper.GetComponent<Slider>().value.ToString();
            timeAmount.text = sliderTime.GetComponent<Slider>().value.ToString();
            boardAmount.text = sliderBoard.GetComponent<Slider>().value.ToString();
        }
        else
        {
            sliderBumper.GetComponent<Slider>().value = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "MaxBumperAmount");
            sliderBoard.GetComponent<Slider>().value = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "MaxBoardSize");
            sliderTime.GetComponent<Slider>().value = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "TimerTime");
            bumperAmount.text = sliderBumper.GetComponent<Slider>().value.ToString();
            timeAmount.text = sliderTime.GetComponent<Slider>().value.ToString();
            boardAmount.text = sliderBoard.GetComponent<Slider>().value.ToString();
        }
    }

    public void MaxBumperAmount(float sliderBu)
    {
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "MaxBumperAmount", (int)sliderBu);
        PlayerPrefs.Save();
        bumperAmount.text = sliderBu.ToString();
    }

    public void MaxBoardSize(float sliderBo)
    {
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "MaxBoardSize", (int)sliderBo);
        PlayerPrefs.Save();
        boardAmount.text = sliderBo.ToString();
    }

    public void TimerTime(float sliderTi)
    {
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "TimerTime", (int)sliderTi);
        PlayerPrefs.Save();
        timeAmount.text = sliderTi.ToString();
    }
}
