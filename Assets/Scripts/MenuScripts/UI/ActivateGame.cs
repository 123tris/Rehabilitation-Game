using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateGame : Button_3D {

    public GameObject gameboard;
    public GameObject panelToEnable;
    public GameObject panelToDisable;

    void Start()
    {
        buttonPressed.AddListener(OnStart);
    }

    void OnStart()
    {
        panelToDisable.SetActive(false);
        panelToEnable.SetActive(true);
        gameboard.SetActive(true);
    }
}
