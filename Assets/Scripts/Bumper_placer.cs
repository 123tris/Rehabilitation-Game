using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper_placer : MonoBehaviour {

    public List<GameObject> Bumpers;
    public List<Transform> SpawnPoints;
    public List<GameObject> spawnedBumpers =  new List<GameObject>();
    public int Spawns;
    public int randomspawn;

    public float timer = 5f;
    public bool timerOn;
	
	void Start () {

        timerOn = true;


        for (int i = 0; i < Spawns; i++)
        {
            randomspawn = Random.Range(0, SpawnPoints.Count);

            Transform spawnPosition = SpawnPoints[randomspawn];
            
            GameObject Bumper = Instantiate(Bumpers[Random.Range(0, Bumpers.Count)], spawnPosition);
            SpawnPoints.RemoveAt(randomspawn);
            
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
            for (int i = 0; i < Spawns; i++)
            {
                spawnedBumpers[i].GetComponent<MeshRenderer>().enabled = false;
                Debug.Log("MeshOff");
                timerOn = false;
            }
        }
    }

   public void BumperHit()
    {

    }
}



