using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayBoardSize : MonoBehaviour {

    void ChangeBoardSize(bool toggle)
    {if (toggle == true)
        {
            Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
            Mesh mesh2 = Instantiate(mesh);
            GetComponent<MeshFilter>().sharedMesh = mesh2;
        }
        else
        {

        }
    }
}
