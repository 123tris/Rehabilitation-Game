using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHigherScore : MonoBehaviour {

    [Header("Last Score")]
    public int LastScore;

    [Header("Score Text")]
    public Text score_1_text;
    public Text score_2_text;
    public Text score_3_text;
    public Text score_4_text;
    public Text score_5_text;
    public Text score_6_text;
    public Text score_7_text;
    public Text score_8_text;

    [Header("Scores")]
    public int score_1;
    public int score_2;
    public int score_3;
    public int score_4;
    public int score_5;
    public int score_6;
    public int score_7;
    public int score_8;

    private void Start()
    {
        PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "Score", LastScore);

        PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "Score_1", score_1);
        PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "Score_2", score_2);
        PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "Score_3", score_3);
        PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "Score_4", score_4);
        PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "Score_5", score_5);
        PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "Score_6", score_6);
        PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "Score_7", score_7);
        PlayerPrefs.GetInt("User_" + PlayerPrefs.GetString("User") + "Score_8", score_8);
    }

   public void UpdateScore()
    {
        if(LastScore >= score_1)
        {
            score_1 = LastScore;
            score_1_text.text = score_1.ToString();
            PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "Score_1", score_1);
        }
        else if(LastScore >= score_2){
            score_2 = LastScore;
            score_2_text.text = score_2.ToString();
            PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "Score_2", score_2);
        }
        else if (LastScore >= score_3)
        {
            score_3 = LastScore;
            score_3_text.text = score_3.ToString();
            PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "Score_3", score_3);
        }
        else if (LastScore >= score_4)
        {
            score_4 = LastScore;
            score_4_text.text = score_4.ToString();
            PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "Score_4", score_4);
        }
        else if (LastScore >= score_5)
        {
            score_5 = LastScore;
            score_5_text.text = score_5.ToString();
            PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "Score_5", score_5);
        }
        else if (LastScore >= score_6)
        {
            score_6 = LastScore;
            score_6_text.text = score_6.ToString();
            PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "Score_6", score_6);
        }
        else if (LastScore >= score_7)
        {
            score_7 = LastScore;
            score_7_text.text = score_7.ToString();
            PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "Score_7", score_7);
        }
        else if (LastScore >= score_8)
        {
            score_8 = LastScore;
            score_8_text.text = score_8.ToString();
            PlayerPrefs.SetInt("User_" + PlayerPrefs.GetString("User") + "Score_8", score_8);
    }
  }
}
