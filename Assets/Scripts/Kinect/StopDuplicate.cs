using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopDuplicate : MonoBehaviour {

    GameObject[] duplicateSpawners;
    public int amountOfDuplicates;

    // Update is called once per frame
    void Update () {

        duplicateSpawners = GameObject.FindGameObjectsWithTag("SpawnerBig");
        amountOfDuplicates = duplicateSpawners.Length;

        if(duplicateSpawners.Length > 1)
        {
            Debug.Log("more than 1");
            Destroy(GameObject.FindGameObjectWithTag("SpawnerBig"));
        }
	}
}
