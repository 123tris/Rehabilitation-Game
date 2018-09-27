using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMaker : MonoBehaviour
{
    [Header("building blocks")]
    public GameObject tile;
    public GameObject frame;
    public GameObject corner;
    public List<GameObject> spawnedBoard;

    [Header("external objects and scripts")]
    public Bumper_placer b_p;
    public GameObject tileParent;

    int yAsPosition = 1;
    int yAsFramePosition = 0;



    public void BuildBoard()
    {



        for (int i = 1; i < b_p.board.GetLength(0) - 1; i++)
        {
            for (int k = 1; k < b_p.board.GetLength(0) - 1; k++)
            {
                Vector3 position = GetSpawnTilePositionByIndex(k, yAsPosition);

                GameObject instantiatedBumper = Instantiate(tile, tileParent.transform);
                spawnedBoard.Add(instantiatedBumper);
                instantiatedBumper.transform.position = position;
                if (k == b_p.board.GetLength(0) - 2)
                {
                    yAsPosition += 1;
                }
            }
        }

        for (int i = 0; i < 2; i++)
        {
            for (int k = 0; k < b_p.board.GetLength(0); k++)
            {
                Vector3 xposition = GetSpawnFramePositionByIndex(k, yAsFramePosition);
                Vector3 yposition = GetSpawnFramePositionByIndex(yAsFramePosition, k);

                if (k == b_p.board.GetLength(0) - 1)
                {
                    GameObject instantiatedXFrame = Instantiate(corner, tileParent.transform);
                    spawnedBoard.Add(instantiatedXFrame);
                    instantiatedXFrame.transform.position = xposition;

                    GameObject instantiatedYFrame = Instantiate(corner, tileParent.transform);
                    spawnedBoard.Add(instantiatedYFrame);
                    instantiatedYFrame.transform.position = yposition;
                }
                else if(k != 0)
                {
                    GameObject instantiatedXFrame = Instantiate(frame, tileParent.transform);
                    spawnedBoard.Add(instantiatedXFrame);
                    instantiatedXFrame.transform.position = xposition;

                    GameObject instantiatedYFrame = Instantiate(frame, tileParent.transform);
                    spawnedBoard.Add(instantiatedYFrame);
                    instantiatedYFrame.transform.position = yposition;
                }
                else
                {
                    GameObject instantiatedXFrame = Instantiate(corner, tileParent.transform);
                    spawnedBoard.Add(instantiatedXFrame);
                    instantiatedXFrame.transform.position = xposition;
                }

                if (k == b_p.board.GetLength(0) - 1)
                {
                    yAsFramePosition += b_p.board.GetLength(0) - 1;
                }
            }
        }
    }

    public Vector3 GetSpawnTilePositionByIndex(int x, int y)
    {
        Vector3 verticalOffset = Vector3.forward * y;
        Vector3 horizontalOffset = Vector3.right * x;
        Vector3 depthOffset = Vector3.down * 0.50f;
        return transform.position + verticalOffset + depthOffset + horizontalOffset;
    }

    public Vector3 GetSpawnFramePositionByIndex(float x, float y)
    {
        Vector3 verticalOffset = Vector3.forward * y;
        Vector3 horizontalOffset = Vector3.right * x;
        Vector3 depthOffset = Vector3.down * 0.20f;
        return transform.position + verticalOffset+ depthOffset + horizontalOffset;
    }

}
