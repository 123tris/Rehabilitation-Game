using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScore : LeaderBoard {

    int score;
    string accountName;
    int diffuculty;

	public void GiveScore()
    {
        AddScore(accountName,diffuculty,score);
    }
}
