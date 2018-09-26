using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMaker : MonoBehaviour
{
    [Header("building blocks")]
    public GameObject tile;
    public List<GameObject> spawnedBoard;

    public Bumper_placer b_p;

    public void BuildBoard()
    {
        for (int i = 1; i < b_p.board.GetLength(0) - 1; i++)
        {
            for (int k = 0; k < i; k++)
            {
                int yAsPosition=1;
                
                Vector3 position = b_p.GetSpawnPositionByIndex(i, yAsPosition);

                GameObject instantiatedBumper = Instantiate(tile, transform);
                spawnedBoard.Add(instantiatedBumper);
                instantiatedBumper.transform.position = position;
                if(k == i && i == b_p.board.GetLength(0) - 1)
                {
                    yAsPosition =+ 1;
                    k = 0;
                }
            }
        }
    }

}
