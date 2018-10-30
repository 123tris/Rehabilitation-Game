﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointSystem : MonoBehaviour
{
    [Header("Texts")]
    public Text points_Var;

    [Header("Objects")]
    public GameObject spawnSmall, spawnBig;

    [Header("Scores")]
    public int score;
    public int targetScore;
    public int pointSlider;

    [Header("Scripts")]
    public PlayerHigherScore b_h_S;

    public void LoadScore()
    {
        score = 0;
        targetScore = 0;
        pointSlider = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "PointAmount");
    }
    public void AddPoints()
    {
        PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "PointAmount");
        score += 100 * (targetScore + 1);
        targetScore += 1;
        points_Var.text = score.ToString();
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "Score", score);
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "TargetScore", targetScore);
        b_h_S.UpdateScore();
        if (targetScore == 2 + (1 * pointSlider) || targetScore == 6 + (1 * pointSlider) || targetScore == 10 + (1 * pointSlider) || targetScore == 12 + (1 * pointSlider))
        {
            spawnSmall.GetComponent<Bumper_placer>().LevelUpTile();
            spawnBig.GetComponent<Bumper_placer>().LevelUpTile();
        }
        else if (targetScore == 4 + (1 * pointSlider) || targetScore == 8 + (1 * pointSlider))
        {
            spawnSmall.GetComponent<Bumper_placer>().LevelUpBoard();
            spawnBig.GetComponent<Bumper_placer>().LevelUpBoard();
        }
    }

    public void Missed()
    {
        PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "PointAmount");
        if (targetScore >= 1)
            targetScore -= 1;
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "TargetScore", targetScore);
        if (targetScore == 1 + (1 * pointSlider) || targetScore == 5 + (1 * pointSlider) || targetScore == 9 + (1 * pointSlider) || targetScore == 11 + (1 * pointSlider))
        {
            spawnSmall.GetComponent<Bumper_placer>().LevelDownTile();
            spawnBig.GetComponent<Bumper_placer>().LevelDownTile();
        }
        else if (targetScore == 3 + (1 * pointSlider) || targetScore == 7 + (1 * pointSlider))
        {
            spawnSmall.GetComponent<Bumper_placer>().LevelDownBoard();
            spawnBig.GetComponent<Bumper_placer>().LevelDownBoard();
        }
    }

    //public void DeleteScore()
    //{
    //    PlayerPrefs.DeleteKey("User_" + PlayerPrefs.GetString("User") + "Score");
    //}

    public void ResetScene()
    {
        spawnSmall = GameObject.FindGameObjectWithTag("SpawnerKlein");
        spawnBig = GameObject.FindGameObjectWithTag("SpawnerBig");
        PlayerPrefs.DeleteKey("User_" + PlayerPrefs.GetString("User") + "Score");
        PlayerPrefs.DeleteKey("User_" + PlayerPrefs.GetString("User") + "TargetScore");
        PlayerPrefs.DeleteKey("User_" + PlayerPrefs.GetString("User") + "BumperAmount");
        PlayerPrefs.DeleteKey("User_" + PlayerPrefs.GetString("User") + "BoardSize");
        spawnSmall.GetComponent<Bumper_placer>().testBumpersToSpawn = 1;
        spawnBig.GetComponent<Bumper_placer>().testBumpersToSpawn = 1;
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "BumperAmount", spawnSmall.GetComponent<Bumper_placer>().testBumpersToSpawn);
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "BumperAmount", spawnBig.GetComponent<Bumper_placer>().testBumpersToSpawn);
        spawnSmall.GetComponent<Bumper_placer>().boardSize = 5;
        spawnBig.GetComponent<Bumper_placer>().boardSize = 5;
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "BoardSize", spawnSmall.GetComponent<Bumper_placer>().boardSize);
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "BoardSize", spawnBig.GetComponent<Bumper_placer>().boardSize);
        points_Var.text = "0";
    }
}
