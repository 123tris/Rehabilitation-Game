using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayBoardSize : MonoBehaviour
{

    public GameObject bigGameBoard, smallGameBoard;
    public GameObject spawner;

    public void ChangeBoardSize(bool toggle)
    {
        if (toggle == true)
        {
            smallGameBoard.SetActive(true);
            bigGameBoard.SetActive(false);
            spawner.transform.localScale = new Vector3(33.33334f, 33.33334f, 33.33334f) * 0.78947368f;
        }
        else
        {
            bigGameBoard.SetActive(true);
            smallGameBoard.SetActive(false);
            spawner.transform.localScale = new Vector3(33.33334f, 33.33334f, 33.33334f) * 1.26666667f;
        }
    }
}
