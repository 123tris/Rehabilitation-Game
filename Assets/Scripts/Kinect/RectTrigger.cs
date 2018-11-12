using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectTrigger : MonoBehaviour
{
    Ball_Spawn ballSpawn;

    public GameObject spawnBig, spawnSmall;
    public GameObject panelToDisable;
    public GameObject panelToEnable;

    private Camera mCamera = null;
    private Renderer mMaterial = null;

    public ChangePlayBoardSize c_p_b;

    public int motionHit = 0;

    float timer = 0;

    private void Awake()
    {
        ballSpawn = FindObjectOfType<Ball_Spawn>();
        mCamera = Camera.main;
    }

    public void CheckHit()
    {
        if (motionHit > 6)
        {
            timer += Time.deltaTime;
            if (ballSpawn.rend == null && timer > 2)
            {
                if(gameObject.tag == "PauzeButtons")
                {
                    spawnSmall = GameObject.FindGameObjectWithTag("SpawnerKlein");
                    spawnBig = GameObject.FindGameObjectWithTag("SpawnerBig");
                    panelToDisable.SetActive(false);

                    if (c_p_b.isBoardSmall == true)
                    {
                        foreach (Transform child in spawnSmall.transform)
                        {
                            child.gameObject.SetActive(false);
                        }
                        spawnSmall.GetComponent<Bumper_placer>().enabled = false;
                    }
                    else
                    {
                        foreach (Transform child in spawnBig.transform)
                        {
                            child.gameObject.SetActive(false);
                        }
                        spawnBig.GetComponent<Bumper_placer>().enabled = false;
                    }

                    panelToEnable.SetActive(true);
                    Debug.Log("Pauze test");
                    timer = 0.0f;
                }
                else if(ballSpawn.rend == null)
                {
                    ballSpawn.target = this.gameObject;
                    gameObject.name = "target";
                    GetComponent<Renderer>().sharedMaterial = ballSpawn.clicked_mat;
                    ballSpawn.rend = GetComponent<Renderer>();
                    ballSpawn.SpawnBall();
                    timer = 0.0f;
                }
            }
        }
        else
        {
            timer = 0.0f;
        }
        motionHit = 0;
    }
}
