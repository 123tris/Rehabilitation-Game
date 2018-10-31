using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffucultyGiver : Button_3D {

    public GetScore getScore;

	public void Easy()
    {
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "TimerTime", 15);
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "BumperAmount", 1);
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "BoardSize", 5);
        getScore.diffuculty = 1;
    }

    public void Medium()
    {
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "TimerTime", 10);
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "BumperAmount", 1);
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "BoardSize", 5);
        getScore.diffuculty = 2;
    }

    public void Hard()
    {
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "TimerTime", 5);
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "BumperAmount", 2);
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "BoardSize", 6);
        getScore.diffuculty = 3;
    }
}
