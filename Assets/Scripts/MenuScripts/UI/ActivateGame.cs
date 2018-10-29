using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateGame : Button_3D
{

    public GameObject spawnBig, spawnSmall;
    public GameObject StartGame;
    public GameObject panelToDisable;
    public ChangePlayBoardSize c_p_b;

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
        spawnSmall = GameObject.FindGameObjectWithTag("SpawnerKlein");
        spawnBig = GameObject.FindGameObjectWithTag("SpawnerBig");
        panelToDisable.SetActive(false);
        if (c_p_b.isBoardSmall == true)
        {
            spawnSmall.GetComponent<Bumper_placer>().enabled = true;
        }
        else
        {
            spawnBig.GetComponent<Bumper_placer>().enabled = true;
        }
    }
}
