using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointSystem : MonoBehaviour
{
    [Header("Texts")]
    public Text points_Var;

    [Header("Scores")]
    public int score;
    public int targetScore;

    [Header("Scripts")]
    public Bumper_placer b_p;

    void Start()
    { 

        // Debug.LogError("Target scores is empty, please fill in the target scores list to indicate then necessary points per round");
        score = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "Score", score);
        targetScore = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "TargetScore", 0);
        points_Var.text = PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "Score").ToString();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }
    }
    public void AddPoints()
    {
        score += 100;
        targetScore += 1;
        points_Var.text = score.ToString();      
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "Score", score);
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "TargetScore", targetScore);
        //Debug.Log(score + "score");
        //Debug.Log(targetScore + "targetscore");
        if (targetScore == 2 || targetScore == 6 || targetScore == 10 || targetScore == 12)
        {
            b_p.LevelUpTile();
        }
        else if (targetScore == 4 || targetScore == 8)
        {
            b_p.LevelUpBoard();
        }
    }

    public void Missed()
    {
        if(targetScore >= 1)
        targetScore -= 1;
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "TargetScore", targetScore);
        //Debug.Log(targetScore + "targetscore");
        if (targetScore == 1 || targetScore == 5 || targetScore == 9 || targetScore == 11)
        {
            b_p.LevelDownTile();
        }
        else if (targetScore == 3 || targetScore == 7)
        {
            b_p.LevelDownBoard();
        }
    }

    void ResetScene()
    {
        PlayerPrefs.DeleteKey("User_" + PlayerPrefs.GetString("User") + "Score");
        PlayerPrefs.DeleteKey("User_" + PlayerPrefs.GetString("User") + "TargetScore");
        PlayerPrefs.DeleteKey("User_" + PlayerPrefs.GetString("User") + "BumperAmount");
        PlayerPrefs.DeleteKey("User_" + PlayerPrefs.GetString("User") + "BoardSize");
        b_p.testBumpersToSpawn = 1;
        PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "BumperAmount", b_p.testBumpersToSpawn);
        b_p.boardSize = 5;
        PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "BoardSize", b_p.boardSize);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
