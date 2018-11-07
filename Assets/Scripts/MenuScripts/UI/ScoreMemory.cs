using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMemory : MonoBehaviour {

    public Text textToGet;
    public Text textToChange;

    private void OnEnable()
    {
        textToChange.text = textToGet.text;
    }
}
