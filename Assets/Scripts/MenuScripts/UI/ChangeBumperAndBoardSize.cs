using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBumperAndBoardSize : MonoBehaviour
{
    public GameObject sliderBumper;
    public GameObject sliderBoard;


    private void Start()
    {
      sliderBumper.GetComponent<Slider>().value = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "MaxBumperAmount");
      sliderBoard.GetComponent<Slider>().value =  PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "MaxBoardSize");
    }

    public void ChangeMaxBumperAmount(float slider)
    {
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "MaxBumperAmount", (int)slider);
    }

    public void MaxBoardSize(float slider)
    {
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "MaxBoardSize", (int)slider);
    }
}
