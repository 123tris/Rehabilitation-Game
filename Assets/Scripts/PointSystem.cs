﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour {

    public Text points_Var;
    int currentLifetimeScore;
    int newLifeTimeScore;

    void Start () {
        currentLifetimeScore = PlayerPrefs.GetInt("LifeTimeScore");
        points_Var.text = currentLifetimeScore.ToString();
    }
	

	void Update () {
		
	}

    public void AddPoints()
    {
         newLifeTimeScore = currentLifetimeScore + 1;
        PlayerPrefs.SetInt("LifeTimeScore", newLifeTimeScore);
    }
}
