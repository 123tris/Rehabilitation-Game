using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMaker : MonoBehaviour
{
    [Header("building blocks")]
    public GameObject tile;
    public GameObject frame;
    public GameObject corner;

    [Header("external objects and scripts")]
    public Bumper_placer b_p;
    public GameObject tileParent;
    public Material[] tileMaterials;
    public Material[] frameMaterials;

    int yAsPosition = 1;
    int yAsFramePosition = 0;

    public void SetBoardPosition()
    {
        for (int i = 0; i < b_p.board.GetLength(0) - 5; i++)
        {
            tileParent.transform.position += Vector3.back * 0.5f;
            tileParent.transform.position += Vector3.left * 0.5f;
        }
    }

    public void BuildBoard()
    {

        for (int i = 1; i < b_p.board.GetLength(0) - 1; i++)
        {
            for (int k = 1; k < b_p.board.GetLength(0) - 1; k++)
            {
                Vector3 position = GetSpawnTilePositionByIndex(k, yAsPosition);

                GameObject instantiatedTile = Instantiate(tile, tileParent.transform);
                instantiatedTile.transform.position = position;
                instantiatedTile.GetComponent<Renderer>().material = tileMaterials[Random.Range(0, tileMaterials.Length)];
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

                if (k != 0 && k != b_p.board.GetLength(0) - 1)
                {
                    GameObject instantiatedXFrame = Instantiate(frame, tileParent.transform);
                    instantiatedXFrame.GetComponent<Renderer>().material = frameMaterials[Random.Range(0, frameMaterials.Length)];
                    if (i == 0)
                    {
                        instantiatedXFrame.transform.position = xposition - new Vector3(0, 0, 0.165f);
                        instantiatedXFrame.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    else
                    {
                        instantiatedXFrame.transform.position = xposition + new Vector3(0, 0, 0.165f);
                    }


                    GameObject instantiatedYFrame = Instantiate(frame, tileParent.transform);
                    instantiatedYFrame.GetComponent<Renderer>().material = frameMaterials[Random.Range(0, frameMaterials.Length)];
                    if (i == 0)
                    {
                        instantiatedYFrame.transform.position = yposition - new Vector3(0.165f, 0, 0);
                        instantiatedYFrame.transform.rotation = Quaternion.Euler(0, -90, 0);
                    }
                    else
                    {
                        instantiatedYFrame.transform.position = yposition + new Vector3(0.165f, 0, 0);
                        instantiatedYFrame.transform.rotation = Quaternion.Euler(0, 90, 0);
                    }
                }

                if (k == b_p.board.GetLength(0) - 1)
                {
                    yAsFramePosition += b_p.board.GetLength(1) - 1;
                }
            }
        }

        //instantiate corner
        GameObject instantiatedXCorner1 = Instantiate(corner, tileParent.transform);
        instantiatedXCorner1.transform.position = GetSpawnFramePositionByIndex(0, 0) - new Vector3(0.17f, 0, 0.17f);
        instantiatedXCorner1.transform.rotation = Quaternion.Euler(0, 180, 0);
        GameObject instantiatedYCorner1 = Instantiate(corner, tileParent.transform);
        instantiatedYCorner1.transform.position = GetSpawnFramePositionByIndex(0, b_p.board.GetLength(1) - 1) - new Vector3(0.17f, 0, -0.17f);
        instantiatedYCorner1.transform.rotation = Quaternion.Euler(0, -180, 0);
        instantiatedYCorner1.transform.localScale = new Vector3(1, 1, -1);
        GameObject instantiatedXCorner2 = Instantiate(corner, tileParent.transform);
        instantiatedXCorner2.transform.position = GetSpawnFramePositionByIndex(b_p.board.GetLength(0) - 1, 0) + new Vector3(0.17f, 0, -0.17f);
        instantiatedXCorner2.transform.localScale = new Vector3(1, 1, -1);
        GameObject instantiatedYCorner2 = Instantiate(corner, tileParent.transform);
        instantiatedYCorner2.transform.position = GetSpawnFramePositionByIndex(b_p.board.GetLength(0) - 1, b_p.board.GetLength(1) - 1) + new Vector3(0.17f, 0, 0.17f);
    }

    //calculate tile positions
    public Vector3 GetSpawnTilePositionByIndex(int x, int y)
    {
        Vector3 verticalOffset = Vector3.forward * y;
        Vector3 horizontalOffset = Vector3.right * x;
        Vector3 depthOffset = Vector3.down * 0.50f;
        return transform.position + verticalOffset + depthOffset + horizontalOffset;
    }

    //calculate frame positions
    public Vector3 GetSpawnFramePositionByIndex(float x, float y)
    {
        Vector3 verticalOffset = Vector3.forward * y;
        Vector3 horizontalOffset = Vector3.right * x;
        Vector3 depthOffset = Vector3.down * 0.20f;
        return transform.position + verticalOffset + depthOffset + horizontalOffset;
    }

}
