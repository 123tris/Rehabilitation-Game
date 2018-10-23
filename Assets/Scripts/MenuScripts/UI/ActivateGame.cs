using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateGame : Button_3D {

    public GameObject gameboard;
    public GameObject StartGame;
    public GameObject panelToEnable;
    public GameObject panelToDisable;

    public MusicController mController;
    public GameObject musicControllerObject;

    void Start()
    {
        buttonPressed.AddListener(OnStart);
        musicControllerObject = GameObject.FindGameObjectWithTag("MusicController");
        mController = musicControllerObject.GetComponent<MusicController>();

    }

    void OnStart()
    {
        panelToDisable.SetActive(false);
        panelToEnable.SetActive(true);
        gameboard.SetActive(true);

        if(panelToEnable.gameObject == StartGame)
        {
            Debug.Log("cahngeaudio");
            mController.GameStarted();

        }
    }
}
