using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //else
        // Debug.LogError("Target scores is empty, please fill in the target scores list to indicate then necessary points per round");
        score = PlayerPrefs.GetInt("Score", score);
        targetScore = PlayerPrefs.GetInt("TargetScore", 0);
        points_Var.text = PlayerPrefs.GetInt("Score").ToString();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }
    public void AddPoints()
    {
        score += 1;
        targetScore += 1;
        points_Var.text = score.ToString();      
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("TargetScore", targetScore);

        if (targetScore >= 2)
        {
            PlayerPrefs.SetInt("TargetScore", 0);
            b_p.testBumpersToSpawn +=1;
            Debug.Log(b_p.testBumpersToSpawn);
        }
    }

    void Reset()
    {
        PlayerPrefs.DeleteKey("Score");
    }
}
