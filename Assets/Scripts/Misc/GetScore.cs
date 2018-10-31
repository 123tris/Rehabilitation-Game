using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScore : LeaderBoard {

    int score;
    string accountName;
    public int diffuculty;
    public PointSystem pointSystem;

	public void GiveScore()
    {
       accountName = PlayerPrefs.GetString("User");
        Debug.Log(PlayerPrefs.GetString("User"));
        score = pointSystem.score;
        AddScore(PlayerPrefs.GetString("User").Trim(), diffuculty,score);
    }
}
