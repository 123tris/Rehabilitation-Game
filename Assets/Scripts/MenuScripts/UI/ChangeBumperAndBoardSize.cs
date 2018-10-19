using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBumperAndBoardSize : MonoBehaviour {

    private void Start()
    {
        ChangeMaxBumperAmount(PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "MaxBumperAmount"));
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
