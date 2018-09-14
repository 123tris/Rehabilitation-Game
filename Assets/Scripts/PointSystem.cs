using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    [Header("Texts")]
    public Text points_Var;

    int score;
    private int targetScore;

    public List<int> targetScores;

    void Start()
    {
        if (targetScores.Count != 0)
        {
            targetScore = targetScores[0];
            targetScores.RemoveAt(0);
        }
        else
            Debug.LogError("Target scores is empty, please fill in the target scores list to indicate then necessary points per round");

        points_Var.text = PlayerPrefs.GetInt("Score").ToString();
    }
    public void AddPoints()
    {
        score++;
        //if (score >= targetScore)
        //{
            //TODO: implement round changes
          //  targetScore = targetScores[0];
            //targetScores.RemoveAt(0);
        //}
        PlayerPrefs.SetInt("Score", score);
        points_Var.text = score.ToString();

    }
}
