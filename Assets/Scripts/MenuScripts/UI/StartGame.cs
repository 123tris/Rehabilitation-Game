using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : Button_3D {

    void Start()
    {
        buttonPressed.AddListener(OnStart);
    }

    void OnStart()
    {
        SceneManager.LoadScene(1);
    }
}
