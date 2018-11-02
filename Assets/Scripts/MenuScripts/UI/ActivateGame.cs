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
    public BoardFlippingTest b_f_Small;
    public BoardFlippingTest b_f_Big;

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
        StartGame.SetActive(true);
        if (c_p_b.isBoardSmall == true)
        {
            spawnSmall = GameObject.FindGameObjectWithTag("SpawnerKlein");

            spawnSmall.GetComponent<Bumper_placer>().enabled = true;
            b_f_Small.GameStart();
        }
        else
        {
            spawnBig = GameObject.FindGameObjectWithTag("SpawnerBig");

            spawnBig.GetComponent<Bumper_placer>().enabled = true;
            b_f_Big.GameStart();
        }
    }
}
