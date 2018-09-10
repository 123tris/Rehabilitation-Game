using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper_placer : MonoBehaviour {


    [Header("External Scripts")]
    public Ball_Spawn b_s;

    [Header("Lists")]
    public List<GameObject> bumpers;
    public List<Transform> spawnPoints;
    public List<GameObject> spawnedBumpers = new List<GameObject>();

    [Header("Misc")]
    public int spawns;  
    public float timer = 5f;
    public bool timerOn;
    int randomspawn;

    void Start () {
        timerOn = true;

        for (int i = 0; i < spawns; i++)
        {
            randomspawn = Random.Range(0, spawnPoints.Count);

            Transform spawnPosition = spawnPoints[randomspawn];
            
            GameObject Bumper = Instantiate(bumpers[Random.Range(0, bumpers.Count)], spawnPosition);
            spawnPoints.RemoveAt(randomspawn);
            
            spawnedBumpers.Add(Bumper);
        }
	}
	
	void Update () {
        BumperTimer();      
	}
    
    void BumperTimer()
    {       
        if (timerOn)
        {
            timer -= Time.deltaTime;
            Debug.Log("Timeronn");
        }

        if (timer <= 0 && timerOn == true)
        {
            //Debug.Log("dede");
            b_s.RandomizerBal();
            for (int i = 0; i < spawns; i++)
            {
                spawnedBumpers[i].GetComponent<MeshRenderer>().enabled = false;
                Debug.Log("MeshOff");             
                timerOn = false;
            }
        }
    }

}



