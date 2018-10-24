using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayBoardSize : MonoBehaviour
{

    public GameObject bigGameBoard, smallGameBoard;
    public GameObject spawner;
    public bool isBoardSmall;

    public void ChangeBoardSize(bool toggle)
    {
        if (toggle == true)
        {
            smallGameBoard.SetActive(true);
            bigGameBoard.SetActive(false);
            spawner.transform.localScale = new Vector3(33.33334f, 33.33334f, 33.33334f) * 0.65999987f;
            spawner.transform.localPosition = new Vector3(44.6f, 100, 44.6f);
            isBoardSmall = true;
        }
        else
        {
            bigGameBoard.SetActive(true);
            smallGameBoard.SetActive(false);
            spawner.transform.localScale = new Vector3(33.33334f, 33.33334f, 33.33334f);
            spawner.transform.localPosition = new Vector3(66.66667f, 100 , 66.66667f);
            isBoardSmall = false;
        }
    }
}
