using System.Collections;
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

    [Header("Scripts")]
    public PlayerHigherScore b_h_S;

    public void LoadScore()
    {
        if (!PlayerPrefs.HasKey("User_" + PlayerPrefs.GetString("User") + "Score"))
        {
            score = 0;
            targetScore = 0;
        }
        else
        {
            score = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "Score", score);
            targetScore = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "TargetScore", 0);
            points_Var.text = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "Score").ToString();
        }
    }
    public void AddPoints()
    {
        spawnSmall = GameObject.FindGameObjectWithTag("SpawnerKlein");
        spawnBig = GameObject.FindGameObjectWithTag("SpawnerBig");
        score += 100 * (targetScore + 1);
        targetScore += 1;
        points_Var.text = score.ToString();
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "Score", score);
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "TargetScore", targetScore);
        b_h_S.UpdateScore();
        if (targetScore == 2 || targetScore == 6 || targetScore == 10 || targetScore == 12)
        {
            spawnSmall.GetComponent<Bumper_placer>().LevelUpTile();
            spawnBig.GetComponent<Bumper_placer>().LevelUpTile();
        }
        else if (targetScore == 4 || targetScore == 8)
        {
            spawnSmall.GetComponent<Bumper_placer>().LevelUpBoard();
            spawnBig.GetComponent<Bumper_placer>().LevelUpBoard();
        }
    }

    public void Missed()
    {
        spawnSmall = GameObject.FindGameObjectWithTag("SpawnerKlein");
        spawnBig = GameObject.FindGameObjectWithTag("SpawnerBig");
        if (targetScore >= 1)
            targetScore -= 1;
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "TargetScore", targetScore);
        if (targetScore == 1 || targetScore == 5 || targetScore == 9 || targetScore == 11)
        {
            spawnSmall.GetComponent<Bumper_placer>().LevelDownTile();
            spawnBig.GetComponent<Bumper_placer>().LevelDownTile();
        }
        else if (targetScore == 3 || targetScore == 7)
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
