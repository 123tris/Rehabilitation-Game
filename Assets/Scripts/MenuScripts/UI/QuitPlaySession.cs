﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitPlaySession : Button_3D
{

    [HideInInspector] public GameObject boardToDeleteSmall,boardToDeleteBig;
    public GameObject panelToEnable;
    public GameObject panelToDisable;
    public GameObject smallBoardToSpawn;
    public GameObject bigBoardToSpawn;
    public ChangePlayBoardSize c_p_b;
    [HideInInspector] public GameObject smallGameBoard, bigGameBoard;

    void Start()
    {
        buttonPressed.AddListener(OnStart);

        smallGameBoard = GameObject.FindGameObjectWithTag("SmallGameBoard");
        bigGameBoard = GameObject.FindGameObjectWithTag("BigGameBoard");
    }

    // Update is called once per frame
    void OnStart()
    {
        GameObject instantiatedObject;

        panelToDisable.SetActive(false);
        panelToEnable.SetActive(true);
        if (c_p_b.isBoardSmall == true)
        {
            instantiatedObject = Instantiate(smallBoardToSpawn, smallGameBoard.transform);
            boardToDeleteSmall = GameObject.FindGameObjectWithTag("SpawnerKlein");
            instantiatedObject.transform.localPosition = boardToDeleteSmall.transform.localPosition;
            Destroy(boardToDeleteSmall);
        }
        else
        {
            instantiatedObject = Instantiate(bigBoardToSpawn, bigGameBoard.transform);
            boardToDeleteBig = GameObject.FindGameObjectWithTag("SpawnerBig");
            instantiatedObject.transform.localPosition = boardToDeleteBig.transform.localPosition;
            Destroy(boardToDeleteBig);
        }

    }
}
