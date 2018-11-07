using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMemory : MonoBehaviour {

    public Text textToGet;
    public Text textToChange;
    public PointSystem pointSystem;
    

    public void GetScore()
    {
        textToChange.text = textToGet.text;
        pointSystem.score = 0;
        textToGet.text = "0";
    }
}
