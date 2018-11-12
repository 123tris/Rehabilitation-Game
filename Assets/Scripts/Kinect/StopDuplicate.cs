using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopDuplicate : MonoBehaviour
{
    GameObject[] duplicateSpawners;

    void Update()
    {
        //searches for all gameobjects with the tag SpawnerBig and puts them in an array
        duplicateSpawners = GameObject.FindGameObjectsWithTag("SpawnerBig");

        //checks if there is more than 1 gameobject in the array
        if (duplicateSpawners.Length > 1)
        {
            //if there is more than 1 gameobject in the array it will destroy 1 of the objects in the array
            Destroy(GameObject.FindGameObjectWithTag("SpawnerBig"));
        }
    }
}
