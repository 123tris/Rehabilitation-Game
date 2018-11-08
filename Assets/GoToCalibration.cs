using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToCalibration : Button_3D
{

    // Use this for initialization
    void Start()
    {
        buttonPressed.AddListener(GoToCalibrationScene);
    }

    // Update is called once per frame
    public void GoToCalibrationScene()
    {
        SceneManager.LoadScene("Automatic calibration test");
    }
}
