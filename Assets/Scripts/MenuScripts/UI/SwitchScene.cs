using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : Button_3D {

    public int sceneToLoad;

    void Start()
    {
        buttonPressed.AddListener(OnStart);
    }

    void OnStart()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
