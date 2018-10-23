using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBumperAndBoardSize : MonoBehaviour
{
    public GameObject sliderBumper;
    public GameObject sliderBoard;


    private void Awake()
    {
        if (!PlayerPrefs.HasKey("User_" + PlayerPrefs.GetString("User") + "MaxBumperAmount"))
        {
            sliderBoard.GetComponent<Slider>().value = 5;
            sliderBumper.GetComponent<Slider>().value = 7;
        }
        else
        {
            sliderBumper.GetComponent<Slider>().value = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "MaxBumperAmount");
            sliderBoard.GetComponent<Slider>().value = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "MaxBoardSize");
        } 
    }

    public void ChangeMaxBumperAmount(float slider)
    {
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "MaxBumperAmount", (int)slider);
        PlayerPrefs.Save();
    }

    public void MaxBoardSize(float slider)
    {
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "MaxBoardSize", (int)slider);
        PlayerPrefs.Save();
    }
}
