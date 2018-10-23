using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayBoardSize : MonoBehaviour
{

    public Mesh bigPlayField;
    public Mesh smallPlayField;

    public void ChangeBoardSize(bool toggle)
    {
        if (toggle == true)
        {
            bigPlayField = GetComponent<MeshFilter>().sharedMesh;
            smallPlayField = Instantiate(bigPlayField);
            GetComponent<MeshFilter>().sharedMesh = smallPlayField;
        }
        else
        {

        }
    }
}
