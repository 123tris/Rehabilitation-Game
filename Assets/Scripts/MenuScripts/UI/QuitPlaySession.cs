using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitPlaySession : Button_3D
{

    //[HideInInspector]
    public GameObject boardToDelete;
    public GameObject panelToEnable;
    public GameObject panelToDisable;
    public GameObject smallBoardToSpawn;
    public GameObject bigBoardToSpawn;
    public ChangePlayBoardSize c_p_b;
    [HideInInspector] public GameObject smallGameBoard, bigGameBoard;
    [HideInInspector] public BoardFlippingTest b_f_t_Small, b_f_t_Big;

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
            b_f_t_Small = smallGameBoard.GetComponent<BoardFlippingTest>();
            boardToDelete = GameObject.FindGameObjectWithTag("SpawnerKlein");
            instantiatedObject = Instantiate(smallBoardToSpawn, smallGameBoard.transform);
            instantiatedObject.transform.localPosition = new Vector3(66.66666f, 20, 70.26167f);
            instantiatedObject.GetComponent<Bumper_placer>().enabled = true;
            b_f_t_Small.GameEnd();
            b_f_t_Small.stance = 0;
            Destroy(boardToDelete);
        }
        else
        {
            b_f_t_Big = bigGameBoard.GetComponent<BoardFlippingTest>();
            Debug.Log("shot");
            boardToDelete = GameObject.FindGameObjectWithTag("SpawnerBig");
            instantiatedObject = Instantiate(bigBoardToSpawn, bigGameBoard.transform);
            instantiatedObject.transform.localPosition = new Vector3(66.66666f, 28, 70.26167f);
            instantiatedObject.GetComponent<Bumper_placer>().enabled = true;
            b_f_t_Big.GameEnd();
            b_f_t_Big.stance = 0;
            //boardToDelete.SetActive(false);
            Destroy(boardToDelete);
        }

    }
}
