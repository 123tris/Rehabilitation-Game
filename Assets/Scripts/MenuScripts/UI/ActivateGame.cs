using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateGame : Button_3D {

    public GameObject gameboard;

    void Start()
    {
        buttonPressed.AddListener(OnStart);
    }

    void OnStart()
    {
        gameboard.SetActive(true);
    }
}
