using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : Button_3D {

    void Start()
    {
        buttonPressed.AddListener(OnStart);
    }

    void OnStart()
    {
        Application.Quit();
    }
}
