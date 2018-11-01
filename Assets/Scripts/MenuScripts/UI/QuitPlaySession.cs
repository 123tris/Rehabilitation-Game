using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitPlaySession : Button_3D
{

    [HideInInspector] public GameObject boardToDeleteSmall,boardToDeleteBig;
    public GameObject panelToEnable;
    public GameObject panelToDisable;
    public GameObject smallBoardToSpawn;
    public GameObject bigBoardToSpawn;
    public ChangePlayBoardSize c_p_b;
    [HideInInspector] public GameObject smallGameBoard, bigGameBoard;
    public PointSystem pointSystem;
    public Text points_Var;

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
        pointSystem.score = 0;
        points_Var.text = "0";
        if (c_p_b.isBoardSmall == true)
        {
            boardToDeleteSmall = GameObject.FindGameObjectWithTag("SpawnerKlein");
            instantiatedObject = Instantiate(smallBoardToSpawn, smallGameBoard.transform);
            instantiatedObject.transform.localPosition = boardToDeleteSmall.transform.localPosition;
            Destroy(boardToDeleteSmall);
        }
        else
        {
            boardToDeleteBig = GameObject.FindGameObjectWithTag("SpawnerBig");
            instantiatedObject = Instantiate(bigBoardToSpawn, bigGameBoard.transform);
            instantiatedObject.transform.localPosition = boardToDeleteBig.transform.localPosition;
            Destroy(boardToDeleteBig);
        }

    }
}
