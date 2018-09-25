using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMaker : MonoBehaviour
{
    [Header("building blocks")]
    public GameObject corner;
    public GameObject side;
    public GameObject tile;
    public List<GameObject> spawnedBoard;

    public Bumper_placer b_p;


    public void BuildBoard()
    {
        Vector3 position = new Vector3(1, 1);

        for (int i = 1; i < b_p.board.GetLength(0); i++)
        {
            GameObject instantiatedBoardObject = Instantiate(tile, transform);
            spawnedBoard.Add(instantiatedBoardObject);
            instantiatedBoardObject.transform.position = position;
        }
    }
}
