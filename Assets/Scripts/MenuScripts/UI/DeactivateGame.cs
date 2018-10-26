using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactivateGame : Button_3D {

    public GameObject gameBoardBig, gameBoardSmall;
    public GameObject panelToEnable;
    public GameObject panelToDisable;
    public ChangePlayBoardSize c_p_b;

    void Start()
    {
        buttonPressed.AddListener(OnStart);

    }

    private void FixedUpdate()
    {
        gameBoardSmall = GameObject.Find("SpinFrameKlein").transform.Find("Spawner Small").gameObject;
        gameBoardBig = GameObject.Find("SpinFrameGroot").transform.Find("Spawner Big").gameObject;
    }

    void OnStart()
    {
        panelToDisable.SetActive(false);
        panelToEnable.SetActive(true);
        if (c_p_b.smallGameBoard == true)
        {
            gameBoardSmall.SetActive(false);
        }
        else
        {
            gameBoardBig.SetActive(false);
        }
        panelToDisable.SetActive(false);
        panelToEnable.SetActive(true);
    }
}
